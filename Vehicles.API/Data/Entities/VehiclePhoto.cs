﻿using System.ComponentModel.DataAnnotations;

namespace Vehicles.API.Data.Entities
{
    public class VehiclePhoto
    {
        public int Id { get; set; }

        //[JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

       //TODO: Fix the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://vehicleszulu.azurewebsites.net/images/noimage.png"
            : $"https://vehicleszulu.blob.core.windows.net/vehiclephotos/{ImageId}";
    }
}
