﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Server_SIde.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? InventoryNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public DateTime? YearOfInstalation { get; set; }

        public int MarkId { get; set; }
        public Mark? Mark { get; set; }

        public int WorkshopId { get; set; }
        public Workshop? Workshop { get; set; }
    }
}
