using FluentValidation;
using FluentValidation.Results;
using System;

namespace SelecaoBRQ.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public int Id { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }

        public Guid Guid { get; set; }

        #region Métodos

        protected Entity()
        {
            ValidationResult = new ValidationResult();
            Guid = Guid.NewGuid();
        }

        public abstract bool IsValid();

        public void AddValidationResult(ValidationResult validationResult)
        {
            if (validationResult != null)
                foreach (var error in validationResult.Errors)
                    ValidationResult.Errors.Add(error);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        #endregion
    }
}
