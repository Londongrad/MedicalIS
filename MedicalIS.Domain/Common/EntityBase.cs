namespace MedicalIS.Domain.Common
{
    public abstract class EntityBase
    {
        #region [ Properties ]

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        #endregion [ Properties ]

        #region [ Ctors ]

        /// <summary>Конструктор для EF Core</summary>
        protected EntityBase()
        {
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>Основной конструктор для создания сущности</summary>
        protected EntityBase(Guid id)
        {
            Id = id;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        #endregion [ Ctors ]

        #region [ Methods ]

        /// <summary>Метод для обновления времени редактирования сущности</summary>
        protected void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        #endregion [ Methods ]
    }
}
