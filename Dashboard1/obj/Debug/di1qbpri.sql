CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Menu` (
    `MenuId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Menu` PRIMARY KEY (`MenuId`)
);

CREATE TABLE `Tests` (
    `TestId` int NOT NULL AUTO_INCREMENT,
    `FullName` longtext CHARACTER SET utf8mb4 NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `CategoryId` int NOT NULL,
    `Data` json NULL,
    `ParentTestId` int NOT NULL,
    `ChirdrenTestId` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Tests` PRIMARY KEY (`TestId`),
    CONSTRAINT `FK_Tests_Tests_ParentTestId` FOREIGN KEY (`ParentTestId`) REFERENCES `Tests` (`TestId`) ON DELETE CASCADE
);

CREATE TABLE `MenuItem` (
    `MenuItemId` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `MenuId` int NULL,
    CONSTRAINT `PK_MenuItem` PRIMARY KEY (`MenuItemId`),
    CONSTRAINT `FK_MenuItem_Menu_MenuId` FOREIGN KEY (`MenuId`) REFERENCES `Menu` (`MenuId`) ON DELETE RESTRICT
);

CREATE INDEX `IX_MenuItem_MenuId` ON `MenuItem` (`MenuId`);

CREATE INDEX `IX_Tests_ParentTestId` ON `Tests` (`ParentTestId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20201116073115_InitialCreate', '3.1.9');

