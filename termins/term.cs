//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace termins
{
    using System;
    using System.Collections.Generic;
    
    public partial class term
    {
        public int id { get; set; }
        public string name { get; set; }
        public string meaning { get; set; }
        public string url { get; set; }
        public int scienceid { get; set; }
        public int sourceid { get; set; }
        public int centuryid { get; set; }
        public int eraid { get; set; }
        public int secid { get; set; }
    
        public virtual century century { get; set; }
        public virtual era era { get; set; }
        public virtual science science { get; set; }
        public virtual sec sec { get; set; }
        public virtual source source { get; set; }
    }
}
