using GitHubTeste.Data.DTOs;
using GitHubTeste.Data.Responses;
using GitHubTeste.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GitHubTeste.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubController(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository= gitHubRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("repo")]
        [ProducesResponseType(typeof(RepositoryResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateRepository([FromBody] RepositoryDTO repository)
        {
            try
            {
                var token = HttpContext.Request.Headers["token"];                
                await _gitHubRepository.CreateRepository(token, repository);
                
                return StatusCode(StatusCodes.Status201Created, repository);               
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("branches/{owner}/{repo}")]
        [ProducesResponseType(typeof(List<BranchRepositoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListBranchesRepository(string owner, string repo)
        {
            try
            {
                var token = HttpContext.Request.Headers["token"];
                var result = await _gitHubRepository.ListBranchesRepository(owner, repo, token);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("webhooks/{owner}/{repo}")]
        [ProducesResponseType(typeof(WebhookRepositoryResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateWebhookRepository([FromBody] WebhookRepositoryDTO repository, string owner, string repo)
        {
            try
            {
                var token = HttpContext.Request.Headers["token"];
                await _gitHubRepository.CreateWebhookRepository(owner, repo, token, repository);

                return StatusCode(StatusCodes.Status201Created, repository);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>S
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("webhooks/{owner}/{repo}")]
        [ProducesResponseType(typeof(List<WebhookRepositoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWebhooksFromRepository(string owner, string repo)
        {
            var token = HttpContext.Request.Headers["token"];
            var result = await _gitHubRepository.ListWebhooksRepository(owner, repo, token);

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("webhooks/{owner}/{repo}/{id}")]
        [ProducesResponseType(typeof(WebhookRepositoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> UpdateWebhookRepository([FromBody] UpdateWebhookRepositoryDTO repository, string owner, string repo, string id)
        {
            try
            {
                var token = HttpContext.Request.Headers["token"];
                await _gitHubRepository.UpdateWebhookRepository(token, owner, repo, id, repository);

                return Ok(repository);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
