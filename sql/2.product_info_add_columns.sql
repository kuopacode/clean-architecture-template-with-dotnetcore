ALTER TABLE `product`.`product_infos` 
ADD COLUMN `start_date` DATETIME NULL DEFAULT NULL AFTER `content`,
ADD COLUMN `end_date` DATETIME NULL DEFAULT NULL AFTER `start_date`,
ADD COLUMN `info_type` INT NOT NULL DEFAULT 1 AFTER `end_date`;
