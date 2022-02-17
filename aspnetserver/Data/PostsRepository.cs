using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostsRepository
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return await db.Posts.ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        internal async static Task<Post> GetPostByIdAsync(int postId)
        {
            using (var db = new AppDBContext())
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return db.Posts
                    .FirstOrDefault(post => post.PostId == postId);
#pragma warning restore CS8604 // Possible null reference argument.
               
            }
        }

       // create
       internal async static Task<bool> CreatePostAsync( Post postToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    await db.Posts.AddAsync(postToCreate);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        // Update
        internal async static Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    db.Posts.Update(postToUpdate);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


        // Delete
        internal async static Task<bool> DeletePostAsync(int postId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Post postToDelete = await GetPostByIdAsync(postId);
                    db.Remove(postToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


    }
}
