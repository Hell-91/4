
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/28/2013 23:05:31
-- Generated from EDMX file: D:\Projects\NCRSocialNetwork\NCRSocialNetwork\Models\NCRSocialNetworkDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [NCRSocialNetworkDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClubEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_ClubEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_EventLikeDislikeEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventLikeDislikes] DROP CONSTRAINT [FK_EventLikeDislikeEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_ClubSubscribtionClub]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubSubscribtions] DROP CONSTRAINT [FK_ClubSubscribtionClub];
GO
IF OBJECT_ID(N'[dbo].[FK_EventCommentEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventComments] DROP CONSTRAINT [FK_EventCommentEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_ClubCommentClub]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubComments] DROP CONSTRAINT [FK_ClubCommentClub];
GO
IF OBJECT_ID(N'[dbo].[FK_UserClub_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserClub] DROP CONSTRAINT [FK_UserClub_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserClub_Club]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserClub] DROP CONSTRAINT [FK_UserClub_Club];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEvent_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvent] DROP CONSTRAINT [FK_UserEvent_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEvent_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvent] DROP CONSTRAINT [FK_UserEvent_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEventLikeDislike]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventLikeDislikes] DROP CONSTRAINT [FK_UserEventLikeDislike];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEventComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventComments] DROP CONSTRAINT [FK_UserEventComment];
GO
IF OBJECT_ID(N'[dbo].[FK_UserClubComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubComments] DROP CONSTRAINT [FK_UserClubComment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Clubs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clubs];
GO
IF OBJECT_ID(N'[dbo].[EventComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventComments];
GO
IF OBJECT_ID(N'[dbo].[EventLikeDislikes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventLikeDislikes];
GO
IF OBJECT_ID(N'[dbo].[ClubSubscribtions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClubSubscribtions];
GO
IF OBJECT_ID(N'[dbo].[ClubComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClubComments];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[UserClub]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserClub];
GO
IF OBJECT_ID(N'[dbo].[UserEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserEvent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [EventTitle] nvarchar(max)  NOT NULL,
    [ClubId] int  NOT NULL,
    [EventDescription] nvarchar(max)  NOT NULL,
    [EventLikes] int  NOT NULL,
    [EventDislikes] int  NOT NULL,
    [EventVenue] nvarchar(max)  NOT NULL,
    [EventDate] datetime  NOT NULL
);
GO

-- Creating table 'Clubs'
CREATE TABLE [dbo].[Clubs] (
    [ClubId] int IDENTITY(1,1) NOT NULL,
    [ClubName] nvarchar(max)  NOT NULL,
    [ClubDescription] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EventComments'
CREATE TABLE [dbo].[EventComments] (
    [EventCommentId] int IDENTITY(1,1) NOT NULL,
    [EventId] int  NOT NULL,
    [EventCommentDescription] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'EventLikeDislikes'
CREATE TABLE [dbo].[EventLikeDislikes] (
    [EventLikeDislikeId] int IDENTITY(1,1) NOT NULL,
    [EventId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'ClubSubscribtions'
CREATE TABLE [dbo].[ClubSubscribtions] (
    [ClubSubscriptionId] int IDENTITY(1,1) NOT NULL,
    [ClubId] int  NOT NULL
);
GO

-- Creating table 'ClubComments'
CREATE TABLE [dbo].[ClubComments] (
    [ClubCommentId] int IDENTITY(1,1) NOT NULL,
    [ClubId] int  NOT NULL,
    [ClubCommentDescription] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserFirstName] nvarchar(max)  NULL
);
GO

-- Creating table 'UserClub'
CREATE TABLE [dbo].[UserClub] (
    [Users_UserId] int  NOT NULL,
    [Clubs_ClubId] int  NOT NULL
);
GO

-- Creating table 'UserEvent'
CREATE TABLE [dbo].[UserEvent] (
    [Users_UserId] int  NOT NULL,
    [Events_EventId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EventId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [ClubId] in table 'Clubs'
ALTER TABLE [dbo].[Clubs]
ADD CONSTRAINT [PK_Clubs]
    PRIMARY KEY CLUSTERED ([ClubId] ASC);
GO

-- Creating primary key on [EventCommentId] in table 'EventComments'
ALTER TABLE [dbo].[EventComments]
ADD CONSTRAINT [PK_EventComments]
    PRIMARY KEY CLUSTERED ([EventCommentId] ASC);
GO

-- Creating primary key on [EventLikeDislikeId] in table 'EventLikeDislikes'
ALTER TABLE [dbo].[EventLikeDislikes]
ADD CONSTRAINT [PK_EventLikeDislikes]
    PRIMARY KEY CLUSTERED ([EventLikeDislikeId] ASC);
GO

-- Creating primary key on [ClubSubscriptionId] in table 'ClubSubscribtions'
ALTER TABLE [dbo].[ClubSubscribtions]
ADD CONSTRAINT [PK_ClubSubscribtions]
    PRIMARY KEY CLUSTERED ([ClubSubscriptionId] ASC);
GO

-- Creating primary key on [ClubCommentId] in table 'ClubComments'
ALTER TABLE [dbo].[ClubComments]
ADD CONSTRAINT [PK_ClubComments]
    PRIMARY KEY CLUSTERED ([ClubCommentId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Users_UserId], [Clubs_ClubId] in table 'UserClub'
ALTER TABLE [dbo].[UserClub]
ADD CONSTRAINT [PK_UserClub]
    PRIMARY KEY NONCLUSTERED ([Users_UserId], [Clubs_ClubId] ASC);
GO

-- Creating primary key on [Users_UserId], [Events_EventId] in table 'UserEvent'
ALTER TABLE [dbo].[UserEvent]
ADD CONSTRAINT [PK_UserEvent]
    PRIMARY KEY NONCLUSTERED ([Users_UserId], [Events_EventId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClubId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_ClubEvent]
    FOREIGN KEY ([ClubId])
    REFERENCES [dbo].[Clubs]
        ([ClubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubEvent'
CREATE INDEX [IX_FK_ClubEvent]
ON [dbo].[Events]
    ([ClubId]);
GO

-- Creating foreign key on [EventId] in table 'EventLikeDislikes'
ALTER TABLE [dbo].[EventLikeDislikes]
ADD CONSTRAINT [FK_EventLikeDislikeEvent]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventLikeDislikeEvent'
CREATE INDEX [IX_FK_EventLikeDislikeEvent]
ON [dbo].[EventLikeDislikes]
    ([EventId]);
GO

-- Creating foreign key on [ClubId] in table 'ClubSubscribtions'
ALTER TABLE [dbo].[ClubSubscribtions]
ADD CONSTRAINT [FK_ClubSubscribtionClub]
    FOREIGN KEY ([ClubId])
    REFERENCES [dbo].[Clubs]
        ([ClubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubSubscribtionClub'
CREATE INDEX [IX_FK_ClubSubscribtionClub]
ON [dbo].[ClubSubscribtions]
    ([ClubId]);
GO

-- Creating foreign key on [EventId] in table 'EventComments'
ALTER TABLE [dbo].[EventComments]
ADD CONSTRAINT [FK_EventCommentEvent]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventCommentEvent'
CREATE INDEX [IX_FK_EventCommentEvent]
ON [dbo].[EventComments]
    ([EventId]);
GO

-- Creating foreign key on [ClubId] in table 'ClubComments'
ALTER TABLE [dbo].[ClubComments]
ADD CONSTRAINT [FK_ClubCommentClub]
    FOREIGN KEY ([ClubId])
    REFERENCES [dbo].[Clubs]
        ([ClubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubCommentClub'
CREATE INDEX [IX_FK_ClubCommentClub]
ON [dbo].[ClubComments]
    ([ClubId]);
GO

-- Creating foreign key on [Users_UserId] in table 'UserClub'
ALTER TABLE [dbo].[UserClub]
ADD CONSTRAINT [FK_UserClub_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Clubs_ClubId] in table 'UserClub'
ALTER TABLE [dbo].[UserClub]
ADD CONSTRAINT [FK_UserClub_Club]
    FOREIGN KEY ([Clubs_ClubId])
    REFERENCES [dbo].[Clubs]
        ([ClubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserClub_Club'
CREATE INDEX [IX_FK_UserClub_Club]
ON [dbo].[UserClub]
    ([Clubs_ClubId]);
GO

-- Creating foreign key on [Users_UserId] in table 'UserEvent'
ALTER TABLE [dbo].[UserEvent]
ADD CONSTRAINT [FK_UserEvent_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Events_EventId] in table 'UserEvent'
ALTER TABLE [dbo].[UserEvent]
ADD CONSTRAINT [FK_UserEvent_Event]
    FOREIGN KEY ([Events_EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEvent_Event'
CREATE INDEX [IX_FK_UserEvent_Event]
ON [dbo].[UserEvent]
    ([Events_EventId]);
GO

-- Creating foreign key on [UserId] in table 'EventLikeDislikes'
ALTER TABLE [dbo].[EventLikeDislikes]
ADD CONSTRAINT [FK_UserEventLikeDislike]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEventLikeDislike'
CREATE INDEX [IX_FK_UserEventLikeDislike]
ON [dbo].[EventLikeDislikes]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'EventComments'
ALTER TABLE [dbo].[EventComments]
ADD CONSTRAINT [FK_UserEventComment]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEventComment'
CREATE INDEX [IX_FK_UserEventComment]
ON [dbo].[EventComments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'ClubComments'
ALTER TABLE [dbo].[ClubComments]
ADD CONSTRAINT [FK_UserClubComment]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserClubComment'
CREATE INDEX [IX_FK_UserClubComment]
ON [dbo].[ClubComments]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------