using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSharing.Contacts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string GetUserByUsername = Base + "/identity/user/{username}";
        }

        public static class Images
        {
            public const string Post = Base + "/images/upload";

            public const string GetAll = Base + "/images";

            public const string Get = Base + "/images/{imageId}";

            public const string GetUserImages = Base + "/images/user";

            public const string Delete = Base + "/images/{imageId}";
        }

        public static class Comments
        {
            public const string Post = Base + "/comments/post";

            public const string Patch = Base + "/comments/patch/{commentId}";

            public const string GetImageComments = Base + "/comments/get/{imageId}";
        }
    }
}
