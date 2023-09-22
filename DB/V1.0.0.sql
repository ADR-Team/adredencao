-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema adredencao_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema adredencao_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `adredencao_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `adredencao_db` ;

-- -----------------------------------------------------
-- Table `adredencao_db`.`ecclesiastical_positions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`ecclesiastical_positions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`roles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `name_complete` VARCHAR(45) NOT NULL,
  `email` VARCHAR(30) NOT NULL,
  `cpf` VARCHAR(15) NOT NULL,
  `rg` VARCHAR(15) NOT NULL,
  `gender` SMALLINT NOT NULL,
  `name_mother` VARCHAR(45) NOT NULL,
  `name_father` VARCHAR(45) NULL DEFAULT NULL,
  `profession` VARCHAR(45) NULL DEFAULT NULL,
  `employed` TINYINT(1) NULL DEFAULT NULL,
  `education` SMALLINT NULL DEFAULT NULL,
  `date_of_birth` DATE NOT NULL,
  `date_of_baptism` DATE NULL DEFAULT NULL,
  `date_of_union` DATE NULL DEFAULT NULL,
  `marital_status` SMALLINT NOT NULL,
  `is_a_leader` SMALLINT NOT NULL,
  `situation` SMALLINT NOT NULL,
  `role_id` INT NOT NULL,
  `ecclesiastical_position_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) VISIBLE,
  UNIQUE INDEX `rg_UNIQUE` (`rg` ASC) VISIBLE,
  INDEX `fk_roles_idx` (`role_id` ASC) VISIBLE,
  INDEX `fk_ecclesiatical_posicional_idx` (`ecclesiastical_position_id` ASC) VISIBLE,
  CONSTRAINT `fk_ecclesiatical_posicional`
    FOREIGN KEY (`ecclesiastical_position_id`)
    REFERENCES `adredencao_db`.`ecclesiastical_positions` (`id`),
  CONSTRAINT `fk_roles`
    FOREIGN KEY (`role_id`)
    REFERENCES `adredencao_db`.`roles` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`address`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`address` (
  `id` INT NOT NULL,
  `street` VARCHAR(45) NOT NULL,
  `number` VARCHAR(45) NOT NULL,
  `district` VARCHAR(45) NOT NULL,
  `zip_code` VARCHAR(45) NOT NULL,
  `add_on_address` VARCHAR(45) NULL DEFAULT NULL,
  `city` VARCHAR(45) NOT NULL,
  `state` VARCHAR(45) NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_user_id_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_user_id`
    FOREIGN KEY (`user_id`)
    REFERENCES `adredencao_db`.`users` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`churches`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`churches` (
  `id` INT NOT NULL,
  `churche` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`address_churches`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`address_churches` (
  `id` INT NOT NULL,
  `street` VARCHAR(45) NOT NULL,
  `number` VARCHAR(45) NOT NULL,
  `district` VARCHAR(45) NOT NULL,
  `zip_code` VARCHAR(45) NOT NULL,
  `add_on_address` VARCHAR(45) NULL DEFAULT NULL,
  `city` VARCHAR(45) NOT NULL,
  `state` VARCHAR(45) NOT NULL,
  `churche_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_churche_id_idx` (`churche_id` ASC) VISIBLE,
  CONSTRAINT `fk_churche_id`
    FOREIGN KEY (`churche_id`)
    REFERENCES `adredencao_db`.`churches` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`events`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`events` (
  `id` INT NOT NULL,
  `title` VARCHAR(45) NOT NULL,
  `description` TEXT NOT NULL,
  `date_hour` DATETIME NOT NULL,
  `churche_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `churche_id_idx` (`churche_id` ASC) VISIBLE,
  CONSTRAINT `churche_id`
    FOREIGN KEY (`churche_id`)
    REFERENCES `adredencao_db`.`churches` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`address_events`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`address_events` (
  `id` INT NOT NULL,
  `street` VARCHAR(45) NOT NULL,
  `number` VARCHAR(45) NOT NULL,
  `district` VARCHAR(45) NOT NULL,
  `zip_code` VARCHAR(45) NOT NULL,
  `add_on_address` VARCHAR(45) NULL DEFAULT NULL,
  `city` VARCHAR(45) NOT NULL,
  `state` VARCHAR(45) NOT NULL,
  `event_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_event_id_idx` (`event_id` ASC) VISIBLE,
  CONSTRAINT `fk_event_id`
    FOREIGN KEY (`event_id`)
    REFERENCES `adredencao_db`.`events` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`logs_deletes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`logs_deletes` (
  `id` INT NOT NULL,
  `title` VARCHAR(255) NOT NULL,
  `description` TEXT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_user_id_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_user_id1`
    FOREIGN KEY (`user_id`)
    REFERENCES `adredencao_db`.`users` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`logs_exceptions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`logs_exceptions` (
  `id` INT NOT NULL,
  `title_exception` VARCHAR(255) NOT NULL,
  `summary_exception` VARCHAR(255) NOT NULL,
  `complete_exception` TEXT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_user_id_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_user_id10`
    FOREIGN KEY (`user_id`)
    REFERENCES `adredencao_db`.`users` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`logs_inserts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`logs_inserts` (
  `id` INT NOT NULL,
  `title` VARCHAR(255) NOT NULL,
  `description` TEXT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_user_id_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_user_id_loginsert`
    FOREIGN KEY (`user_id`)
    REFERENCES `adredencao_db`.`users` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`logs_updates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`logs_updates` (
  `id` INT NOT NULL,
  `title` VARCHAR(255) NOT NULL,
  `description` TEXT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_user_id_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_user_id0`
    FOREIGN KEY (`user_id`)
    REFERENCES `adredencao_db`.`users` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `adredencao_db`.`telephones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `adredencao_db`.`telephones` (
  `id` INT NOT NULL,
  `telephone` VARCHAR(45) NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_user_id_idx` (`user_id` ASC) VISIBLE,
  CONSTRAINT `fk_userid`
    FOREIGN KEY (`user_id`)
    REFERENCES `adredencao_db`.`users` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
