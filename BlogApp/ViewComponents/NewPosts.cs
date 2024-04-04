using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.ViewComponents
{
    public class NewPosts:ViewComponent
    {
        private IPostRepository _postRepository;
        public NewPosts(IPostRepository postsRepository){
            _postRepository = postsRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(){
            return View( await
                _postRepository
                .Posts
                .OrderByDescending(p=>p.PublisedOn)
                .Take(5)
                .ToListAsync()
            );
        }
    }
}