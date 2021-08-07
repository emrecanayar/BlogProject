using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammersBlog.Core.Entities.Abstract
{
    //Bu sınıf entitylerde ortak yer alacak olan propertyler için oluşturulmuştur.
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; //override CreatedDate = new DateTime
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string Note { get; set; }

    }
}
