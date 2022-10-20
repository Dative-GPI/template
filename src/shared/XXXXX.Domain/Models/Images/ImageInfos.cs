using System;
using XXXXX.Domain.Enums;

namespace XXXXX.Domain.Models
{
    public class ImageInfos
    {
        public Guid Id { get; set; }
        public Scope Scope { get; set; }
        public Guid? OrganisationId { get; set; }
        public Guid? ApplicationId { get; set; }
        public Guid? UserId { get; set; }

        public  string BlurHash { get ; set; }
        public  int Width { get ; set; }
        public  int Height { get ; set; }
    }
}