using MedicalIS.Domain.Common;

namespace MedicalIS.Domain.Entities
{
    public class Disease : EntityBase
    {
        #region [ Fields ]

        private readonly List<PatientDisease> _patientDiseases = new();

        #endregion [ Fields ]

        #region [ Properties ]

        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }

        /// <summary>Навигационное свойство</summary>
        public IReadOnlyCollection<PatientDisease> PatientDiseases => _patientDiseases;

        #endregion [ Properties ]

        #region [ Ctors ]

        private Disease() { } // EF Core

        public Disease(Guid id, string name, string? description = null)
            : base(id)
        {
            GuardHelper.AgainstEmptyGuid(id, nameof(id));
            GuardHelper.AgainstNullOrEmpty(name, nameof(name));

            Name = name;
            Description = description;
        }

        #endregion [ Ctors ]

        #region [ Methods ]

        public void SetDesctription(string description)
        {
            Description = description;
            UpdateTimestamp();
        }

        #endregion [ Methods ]
    }
}
