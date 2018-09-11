using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StarWars.WebApi
{
    [Route("")]
    public class GraphQLController : ControllerBase
    {
        private readonly DataLoaderDocumentListener _dataLoaderListener;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema, DataLoaderDocumentListener dataLoaderListener)
        {
            _dataLoaderListener = dataLoaderListener;
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            var result = await _documentExecuter.ExecuteAsync(_ =>
                {
                    _.Schema = _schema;
                    _.Query = query.Query;
                    _.Inputs = query.Variables?.ToString().ToInputs();
                    _.Listeners.Add(_dataLoaderListener);
                })
                .ConfigureAwait(false);

            if (result.Errors?.Count > 0)
                return BadRequest(result.Errors);

            return Ok(result);
        }
    }
}
