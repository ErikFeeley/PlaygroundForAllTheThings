using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatrEF6PoC3.Messages.Query;
using MediatR.Pipeline;

namespace MediatrEF6PoC3.MediatrPipeline
{
    public class Pipelines : IRequestPreProcessor<GetMyValueByIdQuery>
    {
        public Task Process(GetMyValueByIdQuery request)
        {
            // do stuff.

            return Task.FromResult(0);
        }
    }
}
