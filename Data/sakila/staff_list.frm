TYPE=VIEW
query=select `s`.`staff_id` AS `ID`,concat(`s`.`first_name`,_utf8\' \',`s`.`last_name`) AS `name`,`a`.`address` AS `address`,`a`.`postal_code` AS `zip code`,`a`.`phone` AS `phone`,`sakila`.`city`.`city` AS `city`,`sakila`.`country`.`country` AS `country`,`s`.`store_id` AS `SID` from (((`sakila`.`staff` `s` join `sakila`.`address` `a` on((`s`.`address_id` = `a`.`address_id`))) join `sakila`.`city` on((`a`.`city_id` = `sakila`.`city`.`city_id`))) join `sakila`.`country` on((`sakila`.`city`.`country_id` = `sakila`.`country`.`country_id`)))
md5=34decdd981cb9330121e0660499b63a7
updatable=1
algorithm=0
definer_user=root
definer_host=localhost
suid=2
with_check_option=0
timestamp=2022-03-24 19:12:55
create-version=1
source=SELECT s.staff_id AS ID, CONCAT(s.first_name, _utf8\' \', s.last_name) AS name, a.address AS address, a.postal_code AS `zip code`, a.phone AS phone,\n	city.city AS city, country.country AS country, s.store_id AS SID\nFROM staff AS s JOIN address AS a ON s.address_id = a.address_id JOIN city ON a.city_id = city.city_id\n	JOIN country ON city.country_id = country.country_id
client_cs_name=latin1
connection_cl_name=latin1_swedish_ci
view_body_utf8=select `s`.`staff_id` AS `ID`,concat(`s`.`first_name`,\' \',`s`.`last_name`) AS `name`,`a`.`address` AS `address`,`a`.`postal_code` AS `zip code`,`a`.`phone` AS `phone`,`sakila`.`city`.`city` AS `city`,`sakila`.`country`.`country` AS `country`,`s`.`store_id` AS `SID` from (((`sakila`.`staff` `s` join `sakila`.`address` `a` on((`s`.`address_id` = `a`.`address_id`))) join `sakila`.`city` on((`a`.`city_id` = `sakila`.`city`.`city_id`))) join `sakila`.`country` on((`sakila`.`city`.`country_id` = `sakila`.`country`.`country_id`)))
