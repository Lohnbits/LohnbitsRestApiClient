#nullable enable

namespace gv3kServerFibuLohn.Api.Data.Main
{
    public interface ILohnbitsSyncApiEmpoyeeMasterData
    {
        public string? Surname { set; get; }

        public string? FirstName { set; get; }

        public string? Street { set; get; }

        public string? HouseNumber { set; get; }

        public string? Postcode { set; get; }

        public string? City { set; get; }

        public string? Country { set; get; }

        public string? MaritalStatus { set; get; }

        public string? Citizenship { set; get; }

        public string? EmploymentStatus { set; get; }

        public string? JobTitle { set; get; }

        public string? Nationality { set; get; }

        public string? EmployeeGroup { set; get; }

        public string? Department { set; get; }

        public string? CostCentre { set; get; }

        public string? Iban { set; get; }

        public string? Gender { set; get; }
    }
}
