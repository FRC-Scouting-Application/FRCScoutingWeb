using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Dbo.Bases
{
    public abstract class DboBase
    {
        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DboBase()
        {
            UpdateRowVersion();
        }

        public void UpdateRowVersion()
        {
            // TODO: Fix Row Version, SQL was wanting to use it as a check for update
            //RowVersion = BitConverter.GetBytes(DateTime.Now.Ticks);
        }
    }
}
