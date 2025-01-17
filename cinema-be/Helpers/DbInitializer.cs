using cinema_be.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema_be.Helpers
{
    public static class DbInitializer
    {
        public static void SeedMovie(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie[]
                {
                    new Movie()
                    {
                        Id = 1,
                        Title = "Вовкулака",
                        Description = "Нова моторошна історія від Blumhouse та режисера-візіонера Лі Воннелла, творців культового трилера «Людина-Невидимка»! Номінант на премію «Золотий глобус» Крістофер Ебботт у ролі Блейка — чоловіка та батька з Сан-Франциско, який успадковує віддалений будинок у сільській місцевості Орегону після таємничого зникнення батька. Оскільки його шлюб знаходиться на межі краху, він переконує дружину разом з донькою відвідати заміський маєток, аби відпочити від метушні міста. Проте спокій не триває довго: після приїзду на родину нападає невидима тварина, змушуючи їх замкнутися у будинку. Із настанням ночі Блейк починає дивно поводитись, перетворюючись на щось невпізнане. Тож його дружині доведеться обирати, чи істота у їхньому домі є більш небезпечною, ніж та, що поза ним.",
                        Duration = new TimeSpan(1, 47, 0),
                        Country = "США",
                        Genre = "хорор",
                        ReleaseDate = new DateTime(2025, 1, 16),
                        EndDate = new DateTime(2025, 1, 29),
                        Director = "Лі Воннелл",
                        Cast = "Крістофер Еббот, Джулія Гарнер та ін.",
                        Rating = 0,
                        TrailerUrl = "https://youtu.be/yr1lPCq3Pek?si=3beHyfKW47vuW-tI",
                        ImageUrl = "https://kino.rv.ua/cover/7nhhk6pio60jdntlmojm.jpg",
                    },
                    new Movie()
                    {
                        Id = 2,
                        Title = "Пригоди Паддінгтона в Перу",
                        Description = "У продовженні історії Паддінгтон разом із сімейством Браун вирушить до Перу, щоб відвідати свою тітку Люсі. Однак їхня подорож не буде звичайною, оскільки загадкові події змусять їх пройти через небезпечні амазонські джунглі та підкорити вершини перуанських гір. На героїв, без сумніву, чекає ще більше захопливих пригод та сміху.",
                        Duration = new TimeSpan(1, 46, 0),
                        Genre = "пригоди, комедія",
                        Country = "Велика Британія, Франція, Японія, США",
                        ReleaseDate = new DateTime(2025, 1, 16),
                        EndDate = new DateTime(2025, 2, 5),
                        Director = "Девід Хейман",
                        Cast = "Хью Бонневіль, Джулі Уолтерс, Олівія Колман, Антоніо Бандерас, Мадлен Харріс, Самюель Джонсон та ін.",
                        Rating = 4,
                        TrailerUrl = "https://youtu.be/0KNaGs2Saeo?si=EckTdjLDtfUTWJI6",
                        ImageUrl = "https://kino.rv.ua/cover/ovj1s4ehkz10ihiusg4q.jpg",
                    },
                    new Movie()
                    {
                        Id = 3,
                        Title = "Злодії 2: Пантера",
                        Description = "Події фільму «Злодії 2: Пантера» відбуваються в Європі. Викрадачі діамантів замислюють неймовірно зухвале пограбування. Їх плани може зіпсувати лише шериф «Великий Нік” О'Брайен. Його напружене протистояння загрозливій банді майстерних злочинців на чолі з Донні Вілсоном триває ще з першого фільму. Та чи буде зведений рахунок цього разу? Коли на кону не лише репутація (престиж), а й мільйони…",
                        Duration = new TimeSpan(2, 0, 0),
                        Genre = "бойовик, трилер, драма, кримінал",
                        Country = "США, Канада, Іспанія",
                        ReleaseDate = new DateTime(2025, 1, 9),
                        EndDate = new DateTime(2025, 1, 22),
                        Director = "Крістіан Будеґаст",
                        Cast = "Джерард Батлер, О’Ши Джексон-мол., Евін Ахмад, Сальваторе Еспозіто, Ріко Вергувен, Свен Теммел та ін.",
                        Rating = 4,
                        TrailerUrl = "https://youtu.be/JXIk6zuSfoU?si=2YVIuJhavxw76rKo",
                        ImageUrl = "https://kino.rv.ua/cover/88lgdn6xvjvujvdac2iw.jpg",
                    },
                }
                );
        }
        public static void SeedSession(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>().HasData(
                new Session[]
                {
                    new Session()
                    {
                        Id = 1,
                        MovieId = 1,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 2,
                        MovieId = 1,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                    new Session()
                    {
                        Id = 3,
                        MovieId = 1,
                        HallId = 1,
                        StartTime = new TimeSpan(19, 55, 0),
                        EndTime = new TimeSpan(21, 45, 0),
                        Date = new DateTime(2025, 1, 20),

                    },
                    new Session()
                    {
                        Id = 4,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(10, 10, 0),
                        EndTime = new TimeSpan(12, 00, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 5,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(16, 20, 0),
                        EndTime = new TimeSpan(18, 10, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 6,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(10, 10, 0),
                        EndTime = new TimeSpan(12, 00, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                    new Session()
                    {
                        Id = 7,
                        MovieId = 2,
                        HallId = 2,
                        StartTime = new TimeSpan(16, 20, 0),
                        EndTime = new TimeSpan(18, 10, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                    new Session()
                    {
                        Id = 8,
                        MovieId = 3,
                        HallId = 3,
                        StartTime = new TimeSpan(20, 10, 0),
                        EndTime = new TimeSpan(22, 10, 0),
                        Date = new DateTime(2025, 1, 18),

                    },
                    new Session()
                    {
                        Id = 9,
                        MovieId = 3,
                        HallId = 3,
                        StartTime = new TimeSpan(20, 10, 0),
                        EndTime = new TimeSpan(22, 10, 0),
                        Date = new DateTime(2025, 1, 19),

                    },
                }
                );
        }
        public static void SeedHall(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hall>().HasData(
                new Hall[]
                {
                    new Hall(){
                        Id = 1,
                        Name="Альфа",
                        Сapacity = 302
                    },
                    new Hall(){
                        Id = 2,
                        Name="Парадиз",
                        Сapacity = 377
                    },
                    new Hall(){
                        Id = 3,
                        Name="Арена",
                        Сapacity = 346
                    },
                });
        }
        public static void SeedBooking(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Booking>().HasData(
                new Booking[]
                {
                    new Booking()
                    {
                        Id = 1,
                        BookingTime= new DateTime(2025,1,17),
                        SessionId = 1,
                        UserId=1,

                    },
                    new Booking()
                    {
                        Id = 2,
                        BookingTime= new DateTime(2025,1,14),
                        SessionId = 8,
                        UserId=2,

                    },
                    new Booking()
                    {
                        Id = 3,
                        BookingTime= new DateTime(2025,1,15),
                        SessionId = 4,
                        UserId=3,

                    },
                    new Booking()
                    {
                        Id = 4,
                        BookingTime= new DateTime(2025,1,17),
                        SessionId = 3,
                        UserId=3,

                    },
                    new Booking()
                    {
                        Id = 5,
                        BookingTime= new DateTime(2025,1,12),
                        SessionId = 2,
                        UserId=4,

                    },
                    new Booking()
                    {
                        Id = 6,
                        BookingTime= new DateTime(2025,1,10),
                        SessionId = 4,
                        UserId=4,

                    },

                }
            );
                
        }
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User()
                    {
                        Id= 1,
                        UserName ="Sasha Osadets",
                        Email = "osadets@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 2,
                        UserName ="Fedor",
                        Email = "fedor@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 3,
                        UserName ="Maksym Banatskyi",
                        Email = "Maksym@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 4,
                        UserName ="Maksym Lazarchuk",
                        Email = "MaksymL@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 5,
                        UserName ="Volodymyr Yakovchuk",
                        Email = "Volodymyr@gmail.com",
                        PasswordHash= "Qwerty!",
                        IsAdmin = false
                    },
                    new User()
                    {
                        Id= 5,
                        UserName ="Admin",
                        Email = "admin@gmail.com",
                        PasswordHash= "psw!admin",
                        IsAdmin = true
                    },
                }
            );
        }
        public static void SeedTicket(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket[]
                {
                    new Ticket()
                    {
                        Id = 1,
                        Price = 250,
                        HallId = 1,
                    },
                    new Ticket()
                    {
                        Id = 2,
                        Price = 220,
                        HallId = 3,
                    },
                    new Ticket()
                    {
                        Id = 3,
                        Price = 230,
                        HallId = 2,
                    },
                });
        }
    }
}
