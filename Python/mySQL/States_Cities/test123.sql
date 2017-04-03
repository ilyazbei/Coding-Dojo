USE mybd123;
select * from states;
INSERT INTO cities(city_Names, created_at, edited_at, states_idstates)
VALUE ('Portland', now(), now(), 2), ('Beaverton', now(), now(), 2);
INSERT INTO businesses(business_Names, created_at, edited_at)
VALUE ('starbucks', now(), now()),('target', now(), now());
INSERT INTO businesses_has_cities(cities_idcities, businesses_idbusinesses)
VALUE (1,1);
INSERT INTO businesses_has_cities(cities_idcities, businesses_idbusinesses)
VALUE (2,1);
INSERT INTO businesses_has_cities(cities_idcities, businesses_idbusinesses)
VALUE (3,2);
INSERT INTO businesses_has_cities(cities_idcities, businesses_idbusinesses)
VALUE (4,1);