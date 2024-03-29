﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSharing.Data;
using ImageSharing.Domain;
using ImageSharing.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImageSharing.Repo
{
    public class ImageRepo : IImageRepo
    {
        private readonly DataContext _context;
        public ImageRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<Image> GetImageByIdAsync(Guid imageId)
        {
            var image = await _context.Images.FirstOrDefaultAsync(u => u.Id == imageId);
            return image;
        }

        public async Task<bool> DeleteImageAsync(Image image)
        {
            _context.Images.Remove(image);
            return await SaveChanges();
        }

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            var images = await _context.Images
                .OrderByDescending(d => d.UploadDate)
                .Take(10)
                .ToListAsync();

            return images;
        }

        public async Task<IEnumerable<Image>> GetUserImagesAsync(Guid userId)
        {
            var images = await _context.Images
                .Where(u => u.UserId == userId.ToString())
                .Take(10)
                .ToListAsync();

            return images;
        }

        public async Task<bool> UploadImageAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            return await SaveChanges();
        }

        private async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
