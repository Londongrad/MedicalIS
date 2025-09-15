using MedicalIS.Domain.Common;

namespace MedicalIS.Domain.Entities
{
    /// <summary>Связка многие-ко-многим</summary>
    public class PatientDisease
    {
        #region [ Properties ]

        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; } = null!;

        public Guid DiseaseId { get; private set; }
        public Disease Disease { get; private set; } = null!;

        public DateTime DiagnosedAt { get; private set; }

        #endregion [ Properties ]

        #region [ Ctors ]

        private PatientDisease() { } // EF Core

        public PatientDisease(Guid patientId, Guid diseaseId, DateTime diagnosedAt)
        {
            GuardHelper.AgainstInvalidDate(diagnosedAt, nameof(diagnosedAt));
            GuardHelper.AgainstEmptyGuid(patientId, nameof(patientId));
            GuardHelper.AgainstEmptyGuid(diseaseId, nameof(diseaseId));

            PatientId = patientId;
            DiseaseId = diseaseId;
            DiagnosedAt = diagnosedAt;
        }

        #endregion [ Ctors ]
    }
}
