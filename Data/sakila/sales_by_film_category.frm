TYPE=VIEW
query=select `c`.`name` AS `category`,sum(`p`.`amount`) AS `total_sales` from (((((`sakila`.`payment` `p` join `sakila`.`rental` `r` on((`p`.`rental_id` = `r`.`rental_id`))) join `sakila`.`inventory` `i` on((`r`.`inventory_id` = `i`.`inventory_id`))) join `sakila`.`film` `f` on((`i`.`film_id` = `f`.`film_id`))) join `sakila`.`film_category` `fc` on((`f`.`film_id` = `fc`.`film_id`))) join `sakila`.`category` `c` on((`fc`.`category_id` = `c`.`category_id`))) group by `c`.`name` order by `total_sales` desc
md5=3812a60ac437dad937e225993cb78468
updatable=0
algorithm=0
definer_user=root
definer_host=localhost
suid=2
with_check_option=0
timestamp=2022-03-24 19:12:55
create-version=1
source=SELECT\nc.name AS category\n, SUM(p.amount) AS total_sales\nFROM payment AS p\nINNER JOIN rental AS r ON p.rental_id = r.rental_id\nINNER JOIN inventory AS i ON r.inventory_id = i.inventory_id\nINNER JOIN film AS f ON i.film_id = f.film_id\nINNER JOIN film_category AS fc ON f.film_id = fc.film_id\nINNER JOIN category AS c ON fc.category_id = c.category_id\nGROUP BY c.name\nORDER BY total_sales DESC
client_cs_name=latin1
connection_cl_name=latin1_swedish_ci
view_body_utf8=select `c`.`name` AS `category`,sum(`p`.`amount`) AS `total_sales` from (((((`sakila`.`payment` `p` join `sakila`.`rental` `r` on((`p`.`rental_id` = `r`.`rental_id`))) join `sakila`.`inventory` `i` on((`r`.`inventory_id` = `i`.`inventory_id`))) join `sakila`.`film` `f` on((`i`.`film_id` = `f`.`film_id`))) join `sakila`.`film_category` `fc` on((`f`.`film_id` = `fc`.`film_id`))) join `sakila`.`category` `c` on((`fc`.`category_id` = `c`.`category_id`))) group by `c`.`name` order by `total_sales` desc
