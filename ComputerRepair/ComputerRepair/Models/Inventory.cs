﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace ComputerRepair
{
    public partial class Inventory
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Comp_Name{ get; set; }
        [Display(Name = "Check In")]
        public System.DateTime Comp_Check_In { get; set; }
        [Display(Name = "Check Out")]
        public System.DateTime Comp_Check_Out { get; set; }
        [Display(Name = "Brand Name")]
        public string Brand_Name { get; set; }
        [Display(Name = "Ram Installed")]
        public bool Is_Ram_Installed { get; set; }
        [Display(Name = "Power Supply Installed")]
        public bool Is_Power_Supply_Installed { get; set; }
        [Display(Name = "Part Type")]
        public string Part_Type { get; set; }
        [Display(Name = "Complete System")]
        public bool Is_Complete_System { get; set; }
        [Display(Name = "Serial Number")]
        public string Serial_Number { get; set; }
        [Display(Name = "Service Number")]
        public string Service_Number { get; set; }
        [Display(Name = "Asset Tags")]
        public bool Is_Asset_Tags { get; set; }
        [Display(Name = "Asset ID")]
        public string Asset_ID { get; set; }
        [Display(Name = "Issues Note")]
        public string Issues_Note { get; set; }
    }
}