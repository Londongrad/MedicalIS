using MedicalIS.Domain.Common;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Domain.Entities
{
    public class Doctor : EntityBase
    {
        #region [ Properties ]

        public string FullName { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public Specialty Specialty { get; private set; }

        #endregion [ Properties ]

        #region [ Ctors ]

        protected Doctor() { } // EF Core

        public Doctor(Guid id, string fullName, string phoneNumber, Specialty scpecialty)
            :base(id)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Specialty = scpecialty;
        }

        #endregion [ Ctors ]

        #region [ Methods ]

        public void ChangePhone(string newPhone)
        {
            PhoneNumber = newPhone;
            UpdateTimestamp();
        }

        public void ChangeSpecialty(Specialty newSpecialty)
        {
            Specialty = newSpecialty;
            UpdateTimestamp();
        }

        #endregion [ Methods ]
    }
}
