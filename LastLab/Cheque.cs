//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LastLab
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cheque
    {
        public int ID_Cheque { get; set; }
        public int Purchase_ID { get; set; }
        public int Customer_ID { get; set; }
        public int TypeOfInterraction_ID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual TypeOfInterraction TypeOfInterraction { get; set; }
    }
}
