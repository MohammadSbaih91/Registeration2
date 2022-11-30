namespace Register2.dal.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstNameAr { get; set; }

        [StringLength(50)]
        public string FirstNameEn { get; set; }

        [StringLength(50)]
        public string LastNameAr { get; set; }

        [StringLength(50)]
        public string LastNameEn { get; set; }

        public bool IsComplete { get; set; }

        public bool IsChangePasswordRequired { get; set; }

        public bool IsChangeUsernameRequired { get; set; }

        [StringLength(50)]
        public string NationalityNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IdCardExpieryDate { get; set; }

        public string IdCardImageURL { get; set; }

        [StringLength(50)]
        public string PassportId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PassportExpieryDate { get; set; }

        public string PassportImageURL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public string ProfileImageURL { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string PostOffice { get; set; }

        public string Address { get; set; }

        public int? ChannelId { get; set; }

        public int? AccountTypeId { get; set; }

        public int? GenderId { get; set; }

        public int? IdCard { get; set; }

        public int? NationalityId { get; set; }

        public int? SocialId { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int LoginAttempts { get; set; }

        [StringLength(50)]
        public string VerificationCode { get; set; }

        public bool MobileNeedsVerification { get; set; }

        [StringLength(10)]
        public string MobileVerificationCode { get; set; }

        public int StatusId { get; set; }

        public bool? FirstTimeRegister { get; set; }

        public bool? IsBlocked { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
