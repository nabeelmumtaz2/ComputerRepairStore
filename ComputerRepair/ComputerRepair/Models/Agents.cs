//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputerRepair
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Agents 
    {
        public int Agent_Id { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Employ_Id { get; set; }
        [Required]
        public System.DateTime Shift_Time { get; set; }
        public Nullable<int> SystemsSystem_Id { get; set; }
    
        public virtual Systems System { get; set; }
    }
}
