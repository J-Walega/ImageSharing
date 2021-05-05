using System;
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

        public async Task<bool> DeleteImageAsync(Image image)
        {
            _context.Images.Remove(image);
            return await SaveChanges();
        }

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            var images = await _context.Images
                .ToListAsync();

            return images;
        }

        public async Task<IEnumerable<Image>> GetUserImagesAsync(Guid userId)
        {
            var images = await _context.Images
                .Where(u => u.Id == userId)
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
