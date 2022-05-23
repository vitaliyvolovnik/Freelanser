using DLL.Context;

namespace DLL.Repository
{
    public class FileRepository : BaseRepository<Domain.Models.File>
    {

        public FileRepository(FreelanserContext context) : base(context)
        {

        }
    }
}
