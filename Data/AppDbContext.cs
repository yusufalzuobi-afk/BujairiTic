using BujairiTic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Order>()
            .Property(o => o.Status)
            .HasConversion<string>();

        builder.Entity<OrderItem>()
            .Property(i => i.Type)
            .HasConversion<string>();

        builder.Entity<OrderItem>()
            .Property(i => i.UnitPrice)
            .HasPrecision(18, 2);

        builder.Entity<OrderItem>()
            .Property(i => i.LineTotal)
            .HasPrecision(18, 2);

        builder.Entity<Restaurant>()
            .Property(r => r.MinimumCharge)
            .HasPrecision(18, 2);

        // =========================
        // SEEDER - الأربع مطاعم
        // =========================
        builder.Entity<Restaurant>().HasData(

           new Restaurant
           {
               Id = 1,
               Name = "برنش آند كيك",
               Type = "عالمي",
               Description = "مطعم عالمي يقدم تجربة فريدة بنكهات أوروبية.",
               ImageUrl = "https://s3.ticketmx.com/uploads/images/dc3da05925e3b013dd31db803aee61002b84c3a5.jpg",
               LogoUrl = "https://s3.ticketmx.com/uploads/images/57bde77de2eab09de36472cb45af748ebd0f883a.jpeg",
               MinimumCharge = 50
           },

    new Restaurant
    {
        Id = 2,
        Name = "كوفا للحلويات",
        Type = "إيطالي",
        Description = "من أقدم محلات الحلويات في إيطاليا.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/c334f0cd19a6d2c6a4dcafd629b171bf52dfa477.jpeg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/12dde91a2e1d0516d29ea50b4bce8e5428a166bc.jpeg",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 3,
        Name = "لونق تشيم",
        Type = "تايلندي",
        Description = "مطعم تايلندي حاصل على نجمة ميشلان.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/4662cdb0543f37db5dd9dd8160c0ffba6958b026.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/681bd55fd60c18086636e068378b27c80f591401.png",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 4,
        Name = "سموير",
        Type = "عربي",
        Description = "مطبخ عربي معاصر بنكهات مبتكرة.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/1cd3c84939397f11560c2182bb849082c8b7780f.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/171328c841175e3868d895bd0596476a2e3d657d.jpeg",
        MinimumCharge = 100
    },

     new Restaurant
     {
         Id = 5,
         Name = "Maiz",
         Type = "سعودي",
         Description = "مطبخ سعودي معاصر.",
         ImageUrl = "https://s3.ticketmx.com/uploads/images/18f0cd54ac1189d4d194483aafa81b19a1d3ea53.jpg",
         LogoUrl = "https://s3.ticketmx.com/uploads/images/2b8446f4a015ab2248a60c6d7aae31e5148b7b69.jpeg",
         MinimumCharge = 50
     },

    new Restaurant
    {
        Id = 6,
        Name = "Sarabeth's",
        Type = "أمريكي",
        Description = "مطعم أمريكي كلاسيكي.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/e2b212c3e3e995fec6aab280de9222e036ea5548.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/6fdd2c48d28d6ae34e943cb991f3f4ac70aba1e3.jpeg",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 7,
        Name = "Villa Mamas",
        Type = "بحريني",
        Description = "نكهات بحرينية تقليدية.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/8ac4478b64d9249e8ea05d819ef894716efcf890.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/d61080bc423e0e9f8a2e168a4966729002b7a7e4.png",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 8,
        Name = "Angelina",
        Type = "فرنسي",
        Description = "مطعم فرنسي راقي.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/62d35c7e8a573ce2e3c2f58fef5bfefb5bd89b0c.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/025684d674038de717849ab7648ac07d9e758380.jpeg",
        MinimumCharge = 100
    },

    new Restaurant
    {
        Id = 9,
        Name = "Sum+Things",
        Type = "عالمي",
        Description = "تجربة طعام عالمية مبتكرة.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/708d2b1f002656fa349b6e1bac06423516b9c940.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/0ccb0c4936c6f8f2bc582de782f586009a79dcb3.jpeg",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 10,
        Name = "Flamingo Room",
        Type = "أوروبي",
        Description = "مطعم أوروبي فاخر.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/6d48728583b18cb8fcd457a955d4de5ecef627e4.jpeg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/4e6f28ff2f9e5b6ec454f69466108ee0d11cca0f.jpeg",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 11,
        Name = "Takya",
        Type = "سعودي",
        Description = "مطعم سعودي عصري.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/3c2475d677b483d98054db4b2056199aa65d6d89.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/d0439724baefb87c36ab9686e0b0c4e47a8df8ff.jpg",
        MinimumCharge = 100
    },

    new Restaurant
    {
        Id = 12,
        Name = "Altopiano",
        Type = "إيطالي",
        Description = "نكهات إيطالية أصيلة.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/e3ec2ab6a7849e584da4a00fb41ef0acdb9d3560.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/f140c9e5e0c441879d2c2d00a42dc1b0a1f87a51.jpg",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 13,
        Name = "African Lounge",
        Type = "أفريقي",
        Description = "مطعم أفريقي فاخر.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/82b7017ee1f5e2aeeeb1976f6b70e2c72681c9ef.png",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/86bf1bacf103acc43409d31b2f39892951546ff2.png",
        MinimumCharge = 150
    },

    new Restaurant
    {
        Id = 14,
        Name = "MAISON ASSOULINE",
        Type = "عالمي",
        Description = "تجربة فاخرة ومميزة.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/513905dc523d74baeae65ca18e304ec12a101745.jpeg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/f7db7cb9aba48e752438edbb8fb33db4a760dedf.jpeg",
        MinimumCharge = 50
    },

    new Restaurant
    {
        Id = 15,
        Name = "Dolce and Gabbana Caffe",
        Type = "إيطالي",
        Description = "مقهى فاخر بطابع إيطالي.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/efdf8102069e93691cdf9874e3a7a68209876169.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/c363428069a78389c5fc6e6a254e67bee14192a1.jpg",
        MinimumCharge = 1
    },

    new Restaurant
    {
        Id = 16,
        Name = "LIZA",
        Type = "عالمي",
        Description = "مطعم بطابع عالمي.",
        ImageUrl = "https://s3.ticketmx.com/uploads/images/db19a6d6edbff851dda08f1ba06b59e935f09640.jpg",
        LogoUrl = "https://s3.ticketmx.com/uploads/images/17fc57d1db0f816371d6c1ef1d6287110a47ef64.png",
        MinimumCharge = 50
    }
        );
    }
}
