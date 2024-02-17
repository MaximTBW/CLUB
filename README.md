# Тема
Автоматизация процессов аренды мальчиков клуба

Описание предметной области
---
Данный проект предназначен для автоматизации аренды у клуба мальчиков клиентами, а также их услуг. 
В проекте присутствует база данных состоящая из следующих таблиц:
 - TClient - таблица, хрянящаяя в себе данные о клиентах;
 - FreeMens - таблица, хрянящаяя в себе данные о мальчиках, которые работают в клубе;
 - Services - таблица, хрянящаяя в себе данные о услугах, предоставляемых клубом (мальчиками);
 - WherePlaces - таблица, хрянящаяя в себе данные о местах, в которых могут проводится услуги;
 - WherePays - таблица, хрянящаяя в себе данные о реквизитах, куда могут скидывать деньги клиенты за аренду;
 - Order - таблица, хрянящаяя в себе данные о заказе, который совершил клиент;

Бизнес домен
---
Клуб мальчиков

Автор
---
Воробьёв Максим Сергеевич студент группы ИП 20-3

## Схема базы данных
```mermaid
erDiagram

    BaseAuditEntity {
        Guid Id
        DateTimeOffset CreatedAt
        string CreatedBy
        DateTimeOffset UpdatedAt
        string UpdatedBy
        DateTimeOffset DeleteddAt
    }

    TClient {
        string Nickname
        int Age
        string PhoneNumber
        string Email
        string AboutHim
    }

    FreeMens {
        string Nickname
        int Age
        string AboutHim
        DateTimeOffset OpenTime
        DateTimeOffset CloseTime
        string MainTongue
        Enum Grade
    }

    Services {
        string ServiceName
        string AboutService
        decimal Price
    }

    WherePays {
        string BankName
        string Nickname
        string CardNumber
    }

    WherePlaces {
        string Adress
        string PlaceName
        DateTimeOffset OpenTime
        DateTimeOffset CloseTime
    }

    Order {
        Guid FreeMenId
        Guid ServiceId
        Guid ClientId
        Guid PlaceId "null"
        Guid PayId "null"
        DateTime OrderTime
        string Comment "null"
    }
    TClient ||--o{ Order: is
    FreeMens ||--o{ Order: is
    Services ||--o{ Order: is
    WherePlaces ||--o{ Order: is
    WherePays ||--o{ Order: is

    BaseAuditEntity ||--o{ TClient: allows
    BaseAuditEntity ||--o{ FreeMens: allows
    BaseAuditEntity ||--o{ Services: allows
    BaseAuditEntity ||--o{ WherePlaces: allows
    BaseAuditEntity ||--o{ WherePays: allows
 ```
SQL скрипт
---
```
USE [CLUB]
GO
INSERT [dbo].[FreeMens] ([Id], [Nickname], [Age], [AboutHim], [OpenTime], [CloseTime], [MainTongue], [Grade], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'2498364a-18d5-4206-9eb1-08d9d849f886', N'Винтовка Александр', 32, N'Большой.', CAST(N'0001-01-01T22:00:00.0010000+00:00' AS DateTimeOffset), CAST(N'0001-01-01T08:00:00.0010000+00:00' AS DateTimeOffset), N'Kotlin', 3, CAST(N'2024-02-17T05:42:00.3339716+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:42:00.3339721+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
INSERT [dbo].[FreeMens] ([Id], [Nickname], [Age], [AboutHim], [OpenTime], [CloseTime], [MainTongue], [Grade], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'03bcbd91-63ff-4c54-8ea5-287f7ca6115e', N'Шварт', 40, N'Опыта у этого умельца предостаточно, правда всегда занят', CAST(N'0001-01-01T12:00:00.0010000+00:00' AS DateTimeOffset), CAST(N'0001-01-01T18:00:00.0010000+00:00' AS DateTimeOffset), N'Assembler', 3, CAST(N'2024-02-17T05:39:54.0292521+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:39:54.0292526+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
INSERT [dbo].[FreeMens] ([Id], [Nickname], [Age], [AboutHim], [OpenTime], [CloseTime], [MainTongue], [Grade], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'9458c278-f489-4431-b232-7c53ee990749', N'Акапулька', 18, N'Самый резвый и активный среди всей бригады', CAST(N'0001-01-01T00:00:00.0010000+00:00' AS DateTimeOffset), CAST(N'0001-01-01T00:00:00.0010000+00:00' AS DateTimeOffset), N'С++', 4, CAST(N'2024-02-17T05:38:21.3295282+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:38:21.3295385+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
GO
INSERT [dbo].[Services] ([Id], [ServiceName], [AboutService], [Price], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'4735f51a-2d83-4e06-8411-6a4f1553cdf4', N'Зализать раны', N'Со всем что на душе и в больной развратной голове поможет наш мастер', CAST(6000.00 AS Decimal(18, 2)), CAST(N'2024-02-17T05:44:09.6036247+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:44:09.6036252+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
INSERT [dbo].[Services] ([Id], [ServiceName], [AboutService], [Price], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'a4f77f77-4486-4339-9f8d-e3cf0b82e7fe', N'Переустановить Windows', N'Мастер приезжает и переустанавливает Windows заказчику.', CAST(4200.00 AS Decimal(18, 2)), CAST(N'2024-02-17T05:43:08.8003135+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:43:08.8003139+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
GO
INSERT [dbo].[TClient] ([Id], [Nickname], [Age], [PhoneNumber], [Email], [AboutHim], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'4dbb734d-b601-4fc4-8d11-4cb27e92eeab', N'Игорев Анатолий Данилович', 28, N'+79111765454', N'plsMark5@please.com', N'Любит пожоще', CAST(N'2024-02-17T05:33:40.4925633+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:33:40.4930602+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
INSERT [dbo].[TClient] ([Id], [Nickname], [Age], [PhoneNumber], [Email], [AboutHim], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'3e3ba595-2a39-4f9e-ac15-4dcbf2fe672b', N'Нифартовый Георг Непалович', 18, N'+79146798265', N'SLESAR.AVTOMEHANNICK@Rabota.ru', N'Молоток и гвозди - вот его призвание', CAST(N'2024-02-17T05:36:43.6818512+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:36:43.6818516+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
INSERT [dbo].[TClient] ([Id], [Nickname], [Age], [PhoneNumber], [Email], [AboutHim], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'6ca21337-0e07-4bca-9231-9090fd2d2be1', N'Даепалов Антон Максимович', 32, N'+79816840230', N'DAM.Secondary@Slave.ru', N'Самый неопытный, пассив', CAST(N'2024-02-17T05:35:16.4097052+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:35:16.4097110+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
GO
INSERT [dbo].[WherePays] ([Id], [BankName], [Nickname], [CardNumber], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'c65b637e-5784-4b0d-be6d-8e4145e2f777', N'Тинькофф', N'Компания ''Хорошие мальчики''', N'2022200209871234', CAST(N'2024-02-17T05:46:25.3060948+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:46:25.3060958+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
INSERT [dbo].[WherePays] ([Id], [BankName], [Nickname], [CardNumber], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'a5ec3564-dfe4-415c-b13a-e4031ff3171c', N'СБЕРБАНК', N'Винтовка CORP.', N'2022200214676831', CAST(N'2024-02-17T05:45:38.3027809+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:45:38.3027914+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
GO
INSERT [dbo].[WherePlaces] ([Id], [Adress], [PlaceName], [OpenTime], [CloseTime], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'0f1df403-9cb1-4611-a708-7030d0639fb2', N'Шуваловский пр-кт, дом 4', N'Мастерская ''У Давидыча''', CAST(N'0001-01-01T12:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'0001-01-01T12:00:00.0000000+00:00' AS DateTimeOffset), CAST(N'2024-02-17T05:48:13.5046691+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:48:13.5046795+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
GO
INSERT [dbo].[Orders] ([Id], [FreeMenId], [ServiceId], [ClientId], [PlaceId], [WherePlaceId], [PayId], [WherePayId], [OrderTime], [Comment], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy], [DeletedAt]) VALUES (N'033f8a39-9aeb-41db-9931-ab2aef48ec90', N'9458c278-f489-4431-b232-7c53ee990749', N'a4f77f77-4486-4339-9f8d-e3cf0b82e7fe', N'6ca21337-0e07-4bca-9231-9090fd2d2be1', NULL, NULL, NULL, NULL, CAST(N'2024-02-17T05:50:18.0548060+00:00' AS DateTimeOffset), N'У заказчика болит спина, с 12 до 18', CAST(N'2024-02-17T05:50:18.0553453+00:00' AS DateTimeOffset), N'CLUB.Api', CAST(N'2024-02-17T05:54:31.0671354+00:00' AS DateTimeOffset), N'CLUB.Api', NULL)
GO
```



