//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HastaneOtomasyon
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReceteDetay
    {
        public int ReceteID { get; set; }
        public int RandevuID { get; set; }
        public int IlacAdet { get; set; }
        public string IlacDozu { get; set; }
        public string KullanımSekli { get; set; }
        public Nullable<int> BarkodNo { get; set; }
    
        public virtual Ilaclar Ilaclar { get; set; }
        public virtual Randevu Randevu { get; set; }
    }
}
