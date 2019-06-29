USE [master]
GO
/****** Object:  Database [Courses]    Script Date: 27/06/2019 12:37:39 م ******/
CREATE DATABASE [Courses]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Courses', FILENAME = N'F:\ITI\Final-Project\last\project\Courses.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Courses_log', FILENAME = N'F:\ITI\Final-Project\last\project\Courses_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Courses] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Courses].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Courses] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Courses] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Courses] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Courses] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Courses] SET ARITHABORT OFF 
GO
ALTER DATABASE [Courses] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Courses] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Courses] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Courses] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Courses] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Courses] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Courses] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Courses] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Courses] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Courses] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Courses] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Courses] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Courses] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Courses] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Courses] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Courses] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Courses] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Courses] SET RECOVERY FULL 
GO
ALTER DATABASE [Courses] SET  MULTI_USER 
GO
ALTER DATABASE [Courses] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Courses] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Courses] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Courses] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Courses] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Courses]
GO
/****** Object:  Table [dbo].[attendance]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attendance](
	[user_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[course_id] [int] NOT NULL,
	[attendant] [bit] NULL,
	[attendant_time] [datetime] NULL,
	[departure] [bit] NULL,
	[departure_time] [datetime] NULL,
 CONSTRAINT [PK_present] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[date] ASC,
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[course]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course](
	[course_id] [int] IDENTITY(1,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[instructor_id] [int] NULL,
	[course_name] [nvarchar](50) NULL,
	[price] [float] NULL,
	[starting_date] [nvarchar](50) NULL,
	[appointments] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[isActive] [bit] NULL,
	[hours_number] [int] NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[courses_category]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_courses_category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[instructor]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instructor](
	[instructor_id] [int] IDENTITY(1,1) NOT NULL,
	[instructor_name] [nvarchar](max) NOT NULL,
	[Current_JobTitle] [nvarchar](max) NULL,
	[NameOf_ItsUnit] [nvarchar](max) NULL,
	[TrainningTopic] [nvarchar](max) NULL,
	[QualificationsName] [nvarchar](max) NULL,
	[phone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_instructor] PRIMARY KEY CLUSTERED 
(
	[instructor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[lab]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lab](
	[lab_id] [int] IDENTITY(1,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[lab_number] [int] NULL,
	[lab_name] [nvarchar](50) NULL,
	[floor_number] [int] NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_labs] PRIMARY KEY CLUSTERED 
(
	[lab_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[news]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news](
	[news_id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[image] [nvarchar](max) NULL,
	[date] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[type_id] [int] NULL,
 CONSTRAINT [PK_news] PRIMARY KEY CLUSTERED 
(
	[news_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[news_type]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news_type](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_news_type] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[parenter]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parenter](
	[parenter_id] [int] IDENTITY(1,1) NOT NULL,
	[parenter_name] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](20) NULL,
	[Mobile] [nvarchar](50) NULL,
 CONSTRAINT [PK_parenters] PRIMARY KEY CLUSTERED 
(
	[parenter_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[qualification]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qualification](
	[qualification_id] [int] IDENTITY(1,1) NOT NULL,
	[qualification_name] [nvarchar](max) NULL,
	[qualification_date] [datetime] NULL,
	[organization] [nvarchar](50) NULL,
 CONSTRAINT [PK_qualifications] PRIMARY KEY CLUSTERED 
(
	[qualification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[services]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[services](
	[service_id] [int] IDENTITY(1,1) NOT NULL,
	[service_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_services] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_course]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_course](
	[user_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[student_degree] [nvarchar](50) NULL,
	[confirmed] [bit] NOT NULL CONSTRAINT [DF_user_course_confirmed]  DEFAULT ((0)),
 CONSTRAINT [PK_student_course] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_data]    Script Date: 27/06/2019 12:37:39 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_data](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[age] [int] NULL,
	[address] [nvarchar](max) NULL,
	[national_id] [nvarchar](14) NOT NULL,
	[qualification_id] [int] NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[role] [bit] NULL CONSTRAINT [df_City]  DEFAULT ((0)),
	[loginUserName] [nvarchar](100) NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (1, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 3, 1, CAST(N'2019-06-27 12:07:52.180' AS DateTime), NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (1, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 4, 1, CAST(N'2019-06-27 12:07:52.180' AS DateTime), NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (2, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 3, 1, CAST(N'2019-06-27 12:13:59.053' AS DateTime), NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (2, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 4, 1, CAST(N'2019-06-27 12:13:59.053' AS DateTime), NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (3, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (3, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 6, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (3, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 7, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (4, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (4, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (4, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 6, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (5, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (5, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (5, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 6, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (7, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (7, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[attendance] ([user_id], [date], [course_id], [attendant], [attendant_time], [departure], [departure_time]) VALUES (7, CAST(N'2019-06-27 00:00:00.000' AS DateTime), 6, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[course] ON 

INSERT [dbo].[course] ([course_id], [service_id], [category_id], [instructor_id], [course_name], [price], [starting_date], [appointments], [description], [isActive], [hours_number]) VALUES (3, 1, 3, 1, N'اعداد القادة', 500, N'1/7/2019', N'10', N'كورس اعداد القادة شهادة معتمدة كورس حكومى', 1, 50)
INSERT [dbo].[course] ([course_id], [service_id], [category_id], [instructor_id], [course_name], [price], [starting_date], [appointments], [description], [isActive], [hours_number]) VALUES (4, 1, 3, 1, N'رسم بورترايه', 200, N'5/8/2019', N'00', N' كورس رسم بورتريه مع المدرب المتميز مناسب للاعمار السنية للاطفال', 1, 50)
INSERT [dbo].[course] ([course_id], [service_id], [category_id], [instructor_id], [course_name], [price], [starting_date], [appointments], [description], [isActive], [hours_number]) VALUES (5, 1, 4, 1, N'data entry', 500, N'5/8/2019', N'00', N'كورس جيد لراغبي تعلم ال data entry ', 1, 70)
INSERT [dbo].[course] ([course_id], [service_id], [category_id], [instructor_id], [course_name], [price], [starting_date], [appointments], [description], [isActive], [hours_number]) VALUES (6, 1, 4, 1, N'برمجة الكترونية', 300, N'5/8/2019', N'00', N'كورس يحتوي على عديد من الموضوعات لتعلم البرمجة', 1, 20)
INSERT [dbo].[course] ([course_id], [service_id], [category_id], [instructor_id], [course_name], [price], [starting_date], [appointments], [description], [isActive], [hours_number]) VALUES (7, 1, 5, 1012, N'js', 2500, N'9-9-2019', N'sat-sun', N'programming', 1, 25)
SET IDENTITY_INSERT [dbo].[course] OFF
SET IDENTITY_INSERT [dbo].[courses_category] ON 

INSERT [dbo].[courses_category] ([category_id], [category_name]) VALUES (3, N'دورات لتنمية مهارات الاطفال')
INSERT [dbo].[courses_category] ([category_id], [category_name]) VALUES (4, N'مجال الحاسب الالي')
INSERT [dbo].[courses_category] ([category_id], [category_name]) VALUES (5, N'اللغات')
INSERT [dbo].[courses_category] ([category_id], [category_name]) VALUES (6, N'برنامج اعداد المدربين TOT')
SET IDENTITY_INSERT [dbo].[courses_category] OFF
SET IDENTITY_INSERT [dbo].[instructor] ON 

INSERT [dbo].[instructor] ([instructor_id], [instructor_name], [Current_JobTitle], [NameOf_ItsUnit], [TrainningTopic], [QualificationsName], [phone], [Mobile], [Email]) VALUES (1, N'uuuuuuuuuuu', N'hjkh', N'jhj', N'wwwwwww', NULL, NULL, NULL, NULL)
INSERT [dbo].[instructor] ([instructor_id], [instructor_name], [Current_JobTitle], [NameOf_ItsUnit], [TrainningTopic], [QualificationsName], [phone], [Mobile], [Email]) VALUES (1012, N'علاء عبد الغني', N'استاذ مساعد', N'جامعة المنوفية', N'تنمية بشرية', N'بكالوريوس هندسة مدنية', N'00', N'00', N'a@a.c')
INSERT [dbo].[instructor] ([instructor_id], [instructor_name], [Current_JobTitle], [NameOf_ItsUnit], [TrainningTopic], [QualificationsName], [phone], [Mobile], [Email]) VALUES (1013, N'محمد صابر حمودة ', N'استاذ مساعد', N'كلية التجارة جامعة المنوفية', N'التنمية البشرية', N'بكالوريوس تجارة', N'5', N'00', N'a@c.c')
SET IDENTITY_INSERT [dbo].[instructor] OFF
SET IDENTITY_INSERT [dbo].[lab] ON 

INSERT [dbo].[lab] ([lab_id], [service_id], [lab_number], [lab_name], [floor_number], [description]) VALUES (1, 1, 1, N'معمل', 1, N'معمل حاسب الي مجهز و يسع 16 فرد')
INSERT [dbo].[lab] ([lab_id], [service_id], [lab_number], [lab_name], [floor_number], [description]) VALUES (2, 1, 2, N'معمل', 1, N'معمل حاسب الي مجهز و يسع22 فرد')
INSERT [dbo].[lab] ([lab_id], [service_id], [lab_number], [lab_name], [floor_number], [description]) VALUES (3, 1, 3, N'قاعة مؤتمرات', 3, N'قاعة مجهزة للاعداد الكبيرة ')
SET IDENTITY_INSERT [dbo].[lab] OFF
SET IDENTITY_INSERT [dbo].[news] ON 

INSERT [dbo].[news] ([news_id], [Title], [image], [date], [description], [type_id]) VALUES (1, N'تنفيذ خطة التدريب الاداري 2018-2019', N'1.jpeg', N'26/6/2019', N'الانتهاء من تنفيذ خطة التدريب الاداري 2018-2019 تنفيذ (26) برنامج لرفع كفاءة العاملين بالديوان العام والوحدات المحلية والقروية والأحياء على مستوى محافظة المنوفية تحت رعاية معالي الوزير اللواء أركان حرب / سعيد عباس محافظ المنوفية قام مركز الدراسات الوطنية التابع لديوان عام محافظة المنوفية والمعتمد على المستوى القومي في التدريب الاداري والحاسب الآلي واللغات من الجهاز المركزي للتنظيم والادارة بالقاهرة . تم الانتهاء من تدريب عدد ( (558 ) موظف من الديوان العام والوحدات المحلية والقروية والأحياء علي مستوي دائرة المحافظة تنفيذاً لخطة التدريب الإداري لعام ( 2018/2019 ) والمدرج بها عدد 26 برنامج تدريبي في كافة التخصصات من أجل رفع كفاءة العاملين وقدم التدريب نخبة من أساتذة الجامعات والمستشارين ومديري عموم علي مستوي المديريات والمحليات .', 1)
INSERT [dbo].[news] ([news_id], [Title], [image], [date], [description], [type_id]) VALUES (2, N'كورس تأهيل', N'2.jpeg', N'24/6/2019', N'كورس تأهيل المرحلة الثانوية في اللغة الإنجليزية مع الاستاذ / وحيد الجبري', 1)
INSERT [dbo].[news] ([news_id], [Title], [image], [date], [description], [type_id]) VALUES (3, N'برنامج اعداد مدربين TOT ', N'3.jpeg', N'20/6/2019', N'تنفيذا لخطة التدريب الاداري الخارجي لمديرية الشئون الصحية بالمنوفية يعقد بمركز الدراسات الوطنية برنامج اعداد مدربين TOT المجموعة الثانية مع الدكتور/ د. شيماء نجيب جامعة المنوفية', 1)
INSERT [dbo].[news] ([news_id], [Title], [image], [date], [description], [type_id]) VALUES (4, N'كورس الكروشية', N'4.jpeg', N'25/6/2019', N'يعلن مركز الدراسات الوطنية عن فتح باب الحجز في كورس الكروشية بسعر 200 ج بدلا من 250 ج', 2)
SET IDENTITY_INSERT [dbo].[news] OFF
SET IDENTITY_INSERT [dbo].[news_type] ON 

INSERT [dbo].[news_type] ([type_id], [type_name]) VALUES (1, N'اخبار')
INSERT [dbo].[news_type] ([type_id], [type_name]) VALUES (2, N'اعلان كورس')
SET IDENTITY_INSERT [dbo].[news_type] OFF
SET IDENTITY_INSERT [dbo].[parenter] ON 

INSERT [dbo].[parenter] ([parenter_id], [parenter_name], [image], [email], [phone], [Mobile]) VALUES (1, N'ITI', N'1.jpg', N'iti@i.com', N'025555555', N'01000000000')
INSERT [dbo].[parenter] ([parenter_id], [parenter_name], [image], [email], [phone], [Mobile]) VALUES (2, N'وزارة الاتصالات و تكنولوجيا المعلومات', N'2.png', N'communication@a.com', N'022558588', N'025558848')
INSERT [dbo].[parenter] ([parenter_id], [parenter_name], [image], [email], [phone], [Mobile]) VALUES (3, N'جامعة عين شمس', N'3.png', N'm@k.c', N'00', N'00')
INSERT [dbo].[parenter] ([parenter_id], [parenter_name], [image], [email], [phone], [Mobile]) VALUES (4, N'الاكاديمية العربية للعللوم و تكنولوجيا النقل البحري', N'0.png', N'm@h.c', N'00', N'00')
INSERT [dbo].[parenter] ([parenter_id], [parenter_name], [image], [email], [phone], [Mobile]) VALUES (5, N'المعهد القومي للاتصالات', N'0.jpg', N'm@h.c', N'00', N'00')
SET IDENTITY_INSERT [dbo].[parenter] OFF
SET IDENTITY_INSERT [dbo].[qualification] ON 

INSERT [dbo].[qualification] ([qualification_id], [qualification_name], [qualification_date], [organization]) VALUES (1, N'موهل1', NULL, NULL)
SET IDENTITY_INSERT [dbo].[qualification] OFF
SET IDENTITY_INSERT [dbo].[services] ON 

INSERT [dbo].[services] ([service_id], [service_name]) VALUES (1, N'كورسات في مختلف المجالات')
INSERT [dbo].[services] ([service_id], [service_name]) VALUES (2, N'قاعات مجهزة')
INSERT [dbo].[services] ([service_id], [service_name]) VALUES (3, N'صيانة اجهزة الحاسب الالي')
INSERT [dbo].[services] ([service_id], [service_name]) VALUES (4, N'مكتبة مجهزة')
SET IDENTITY_INSERT [dbo].[services] OFF
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (1, 3, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (1, 4, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (1, 5, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (2, 3, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (2, 4, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (2, 5, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (2, 6, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (3, 4, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (3, 5, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (3, 6, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (3, 7, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (4, 3, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (4, 4, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (4, 5, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (4, 6, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (5, 3, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (5, 4, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (5, 5, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (5, 6, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (7, 3, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (7, 4, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (7, 5, NULL, 0)
INSERT [dbo].[user_course] ([user_id], [course_id], [student_degree], [confirmed]) VALUES (7, 6, NULL, 0)
SET IDENTITY_INSERT [dbo].[user_data] ON 

INSERT [dbo].[user_data] ([user_id], [user_name], [age], [address], [national_id], [qualification_id], [phone], [email], [role], [loginUserName], [password]) VALUES (1, N'ali', 25, N'aa', N'20123456789123', 1, N'01062010053', N'a@a.a', 1, N'a', N'123')
INSERT [dbo].[user_data] ([user_id], [user_name], [age], [address], [national_id], [qualification_id], [phone], [email], [role], [loginUserName], [password]) VALUES (2, N'a', 25, N'a', N'20123456789123', 1, N'01062010053', N'b@b.b', 0, N'b', N'123')
INSERT [dbo].[user_data] ([user_id], [user_name], [age], [address], [national_id], [qualification_id], [phone], [email], [role], [loginUserName], [password]) VALUES (3, N'maha', 23, N'menofia', N'22345678912345', 1, N'00', N'm@h.c', NULL, N'maha', N'123')
INSERT [dbo].[user_data] ([user_id], [user_name], [age], [address], [national_id], [qualification_id], [phone], [email], [role], [loginUserName], [password]) VALUES (4, N'zzz', 25, N'zz', N'22345678912345', 1, N'01062010053', N'zz@zz.zz', NULL, N'zz', N'12')
INSERT [dbo].[user_data] ([user_id], [user_name], [age], [address], [national_id], [qualification_id], [phone], [email], [role], [loginUserName], [password]) VALUES (5, N'ahmed', 25, N'shebin', N'22345678912345', 1, N'01062010053', N'maikottor25@gmail.com', NULL, N'ahmed', N'123')
INSERT [dbo].[user_data] ([user_id], [user_name], [age], [address], [national_id], [qualification_id], [phone], [email], [role], [loginUserName], [password]) VALUES (7, N'alaa', 25, N'shebin', N'20123564789654', 1, N'01062010053', N'alaa@a.a', 0, N'al', N'123')
SET IDENTITY_INSERT [dbo].[user_data] OFF
ALTER TABLE [dbo].[attendance]  WITH CHECK ADD  CONSTRAINT [FK_attendance_course] FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([course_id])
GO
ALTER TABLE [dbo].[attendance] CHECK CONSTRAINT [FK_attendance_course]
GO
ALTER TABLE [dbo].[attendance]  WITH CHECK ADD  CONSTRAINT [FK_attendance_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[user_data] ([user_id])
GO
ALTER TABLE [dbo].[attendance] CHECK CONSTRAINT [FK_attendance_users]
GO
ALTER TABLE [dbo].[course]  WITH CHECK ADD  CONSTRAINT [FK_course_courses_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[courses_category] ([category_id])
GO
ALTER TABLE [dbo].[course] CHECK CONSTRAINT [FK_course_courses_category]
GO
ALTER TABLE [dbo].[course]  WITH CHECK ADD  CONSTRAINT [FK_course_instructor] FOREIGN KEY([instructor_id])
REFERENCES [dbo].[instructor] ([instructor_id])
GO
ALTER TABLE [dbo].[course] CHECK CONSTRAINT [FK_course_instructor]
GO
ALTER TABLE [dbo].[course]  WITH CHECK ADD  CONSTRAINT [FK_course_services1] FOREIGN KEY([service_id])
REFERENCES [dbo].[services] ([service_id])
GO
ALTER TABLE [dbo].[course] CHECK CONSTRAINT [FK_course_services1]
GO
ALTER TABLE [dbo].[lab]  WITH CHECK ADD  CONSTRAINT [FK_labs_services] FOREIGN KEY([service_id])
REFERENCES [dbo].[services] ([service_id])
GO
ALTER TABLE [dbo].[lab] CHECK CONSTRAINT [FK_labs_services]
GO
ALTER TABLE [dbo].[news]  WITH CHECK ADD  CONSTRAINT [FK_news_news_type] FOREIGN KEY([type_id])
REFERENCES [dbo].[news_type] ([type_id])
GO
ALTER TABLE [dbo].[news] CHECK CONSTRAINT [FK_news_news_type]
GO
ALTER TABLE [dbo].[user_course]  WITH CHECK ADD  CONSTRAINT [FK_student_course_course] FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([course_id])
GO
ALTER TABLE [dbo].[user_course] CHECK CONSTRAINT [FK_student_course_course]
GO
ALTER TABLE [dbo].[user_course]  WITH CHECK ADD  CONSTRAINT [FK_user_course_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[user_data] ([user_id])
GO
ALTER TABLE [dbo].[user_course] CHECK CONSTRAINT [FK_user_course_users]
GO
ALTER TABLE [dbo].[user_data]  WITH CHECK ADD  CONSTRAINT [FK_user_data_qualification] FOREIGN KEY([qualification_id])
REFERENCES [dbo].[qualification] ([qualification_id])
GO
ALTER TABLE [dbo].[user_data] CHECK CONSTRAINT [FK_user_data_qualification]
GO
USE [master]
GO
ALTER DATABASE [Courses] SET  READ_WRITE 
GO
