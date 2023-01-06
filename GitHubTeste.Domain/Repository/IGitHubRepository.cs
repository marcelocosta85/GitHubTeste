using GitHubTeste.Data.DTOs;
using GitHubTeste.Data.Responses;
using Refit;

namespace GitHubTeste.Domain.Repository
{
    [Headers("User-Agent: Refit")]
    public interface IGitHubRepository
    {
        [Post("/user/repos")]
        Task<RepositoryResponse> CreateRepository([Authorize("Bearer")] string token, RepositoryDTO repository);

        [Get("/repos/{owner}/{repo}/branches")]
        Task<List<BranchRepositoryResponse>> ListBranchesRepository([AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [Authorize("Bearer")] string token);

        [Post("/repos/{owner}/{repo}/hooks")]
        Task<WebhookRepositoryResponse> CreateWebhookRepository([AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [Authorize("Bearer")] string token, WebhookRepositoryDTO repository);
        
        [Get("/repos/{owner}/{repo}/hooks")]
        Task<List<WebhookRepositoryResponse>> ListWebhooksRepository([AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [Authorize("Bearer")] string token);

        [Patch("/repos/{owner}/{repo}/hooks/{id}")]
        Task<WebhookRepositoryResponse> UpdateWebhookRepository([Authorize("Bearer")] string token, [AliasAs("owner")] string owner, [AliasAs("repo")] string repo, [AliasAs("id")] string id, UpdateWebhookRepositoryDTO repository);
    }
}
