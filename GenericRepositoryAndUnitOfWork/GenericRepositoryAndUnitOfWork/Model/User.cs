using System.ComponentModel.DataAnnotations;

namespace GenericRepositoryAndUnitOfWork.Model
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName {  get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string Address {  get; set; }
    }
}
