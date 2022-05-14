using DLL.Context;

namespace DLL.Repository
{
    internal class FileRepository : BaseRepository<Domain.Models.File>
    {

        public FileRepository(FreelanserContext context) : base(context)
        {

        }
    }
}
