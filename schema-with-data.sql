CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
);

INSERT INTO `__efmigrationshistory` VALUES ('20210622112112_InitialCommit','3.1.9'),('20210623165313_ChangedTransactionsIdType','3.1.9');

CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) NOT NULL,
  `NormalizedName` varchar(256) NOT NULL,
  `ConcurrencyStamp` text NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
);

INSERT INTO `aspnetroles` VALUES ('084ed224-afb9-47b2-befd-24ad955d9ce9','Admin','ADMIN','b4a0d589-ce67-416d-8d3a-b713b8440462');

CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  `NormalizedUserName` varchar(256) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) DEFAULT NULL,
  `PasswordHash` text NOT NULL,
  `SecurityStamp` text NOT NULL,
  `ConcurrencyStamp` text NOT NULL,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) DEFAULT NULL,
  `TwoFactorEnabled` bit(1) DEFAULT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) DEFAULT NULL,
  `AccessFailedCount` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
);

INSERT INTO `aspnetusers` VALUES ('34e1d913-e23b-4359-8e73-87c76bb7fa6e','admin@easydonate.com','ADMIN@EASYDONATE.COM','admin@easydonate.com','ADMIN@EASYDONATE.COM',_binary '\0','AQAAAAEAACcQAAAAEFvv1btBIg/MxdyDuGVB3+3Bo7m/RYBS1fhILk+IumeTrE9/gozwcDyZmQEC0X7/qw==','IBAL22YCZWIAYROSKXZ3GKQKE4UMZXSR','72992ef9-b362-42e0-b17c-bc107aa3e00f',NULL,_binary '\0',_binary '\0',NULL,_binary '\0',0);;

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
);

INSERT INTO `aspnetuserroles` VALUES ('34e1d913-e23b-4359-8e73-87c76bb7fa6e','084ed224-afb9-47b2-befd-24ad955d9ce9');

CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(256) NOT NULL,
  `ClaimType` varchar(128) DEFAULT NULL,
  `ClaimValue` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` varchar(128) DEFAULT NULL,
  `UserId` varchar(128) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(128) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `category` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(256) NOT NULL,
  `TypeId` int NOT NULL,
  `isActive` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
);

INSERT INTO `category` VALUES (1,'Zakat',1,_binary ''),(2,'Qurbani',2,_binary '');

CREATE TABLE `transaction` (
  `Id` varchar(767) NOT NULL,
  `CategoryId` int NOT NULL,
  `Amount` float NOT NULL,
  `TransactionFees` float NOT NULL,
  `isFeeInclusive` bit(1) NOT NULL,
  `ReferenceTransactionId` varchar(500) NOT NULL,
  `TimeStamp` datetime NOT NULL,
  `SponsorFirstName` varchar(256) DEFAULT NULL,
  `SponsorLastName` varchar(256) DEFAULT NULL,
  `SponsorAddress` varchar(256) DEFAULT NULL,
  `SponsorPostCode` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

INSERT INTO `transaction` VALUES ('2d23ca18-aecb-402d-b238-109bc09e0fa2',2,10000,1.32,_binary '\0','PayPal-11111111111','2021-06-23 21:58:05',NULL,NULL,NULL,NULL),('8a7a924a-c40c-404e-8b6f-02f30efe4940',1,12.4,0.32,_binary '','PayPal-123123-123-123-123','2021-06-23 21:56:55','Ahmad','Ahsan','Pakistan','52250');
