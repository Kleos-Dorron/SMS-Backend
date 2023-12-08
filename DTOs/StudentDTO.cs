using SMS_Backend.Models;
using System.ComponentModel.DataAnnotations;

namespace SMS_Backend.DTOs
{
    public class StudentDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string ContactPerson { get; set; }


        public string ContactNo { get; set; }


        [EmailAddress]
        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Range(0, 150)] // Adjust the range as needed
        public int Age { get; set; }

        public int ClassroomId { get; set; }
    }
}