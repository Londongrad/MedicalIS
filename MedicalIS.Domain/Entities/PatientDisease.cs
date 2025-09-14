namespace MedicalIS.Domain.Entities
{
    /// <summary>Связка многие-ко-многим</summary>
    public class PatientDisease
    {
        #region [ Properties ]

        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; } = null!;

        public Guid DiseaseId { get; private set; }

        /// <summary>Навигационное свойство</summary>
        public Disease Disease { get; private set; } = null!;

        /// <summary>Дата постановки диагноза</summary>
        public DateTime DiagnosedAt { get; private set; }

        #endregion [ Properties ]

        #region [ Ctors ]

        protected PatientDisease() { } // EF Core

        public PatientDisease(Guid patientId, Guid diseaseId, DateTime diagnosedAt)
        {
            PatientId = patientId;
            DiseaseId = diseaseId;
            DiagnosedAt = diagnosedAt;
        }

        #endregion [ Ctors ]
    }
}
