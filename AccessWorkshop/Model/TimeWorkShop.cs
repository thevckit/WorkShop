//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccessWorkshop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeWorkShop
    {
        public int ID { get; set; }
        public int IDWorkShop { get; set; }
        public System.TimeSpan Time { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual WorkShop WorkShop { get; set; }
    }
}
