-- Table: public.Foods

-- DROP TABLE IF EXISTS public."Foods";

CREATE TABLE IF NOT EXISTS public."Foods"
(
    "Id" integer NOT NULL DEFAULT 'nextval('makanan_id_seq'::regclass)',
    "Name" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Price" numeric(10,2) NOT NULL,
    "Description" text COLLATE pg_catalog."default",
    CONSTRAINT makanan_pkey PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Foods"
    OWNER to postgres;


-- Table: public.OrderDetails

-- DROP TABLE IF EXISTS public."OrderDetails";

CREATE TABLE IF NOT EXISTS public."OrderDetails"
(
    "Id" integer NOT NULL DEFAULT 'nextval('detail_pesanan_id_seq'::regclass)',
    "FoodId" integer,
    "OrderId" integer,
    "Quantity" integer NOT NULL,
    "Subtotal" numeric(10,2) NOT NULL,
    "UnitPrice" numeric(10,2) NOT NULL,
    CONSTRAINT detail_pesanan_pkey PRIMARY KEY ("Id"),
    CONSTRAINT food_constraint FOREIGN KEY ("FoodId")
        REFERENCES public."Foods" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT order_constraint FOREIGN KEY ("OrderId")
        REFERENCES public."Orders" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."OrderDetails"
    OWNER to postgres;
-- Index: fki_food_constraint

-- DROP INDEX IF EXISTS public.fki_food_constraint;

CREATE INDEX IF NOT EXISTS fki_food_constraint
    ON public."OrderDetails" USING btree
    ("FoodId" ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: fki_order_constraint

-- DROP INDEX IF EXISTS public.fki_order_constraint;

CREATE INDEX IF NOT EXISTS fki_order_constraint
    ON public."OrderDetails" USING btree
    ("OrderId" ASC NULLS LAST)
    TABLESPACE pg_default;


-- Table: public.Orders

-- DROP TABLE IF EXISTS public."Orders";

CREATE TABLE IF NOT EXISTS public."Orders"
(
    "Id" integer NOT NULL DEFAULT 'nextval('pesanan_id_seq'::regclass)',
    "OrderTime" date NOT NULL DEFAULT 'CURRENT_DATE',
    CONSTRAINT pesanan_pkey PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Orders"
    OWNER to postgres;


-- Table: public.Payments

-- DROP TABLE IF EXISTS public."Payments";

CREATE TABLE IF NOT EXISTS public."Payments"
(
    "Id" integer NOT NULL DEFAULT 'nextval('pembayaran_id_seq'::regclass)',
    "Amount" numeric,
    "OrderId" integer NOT NULL,
    "PaymentDate" date NOT NULL DEFAULT 'CURRENT_DATE',
    CONSTRAINT pembayaran_pkey PRIMARY KEY ("Id"),
    CONSTRAINT "order" FOREIGN KEY ("OrderId")
        REFERENCES public."Orders" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Payments"
    OWNER to postgres;
-- Index: fki_order

-- DROP INDEX IF EXISTS public.fki_order;

CREATE INDEX IF NOT EXISTS fki_order
    ON public."Payments" USING btree
    ("OrderId" ASC NULLS LAST)
    TABLESPACE pg_default;

INSERT INTO Foods (Name, Price, Description) VALUES
    ('Nasi Goreng', 15000.00, 'Nasi goreng dengan telur, ayam, dan sayuran.'),
    ('Mie Ayam', 12000.00, 'Mie dengan potongan ayam, pangsit, dan kuah kaldu.'),
    ('Sate Ayam', 18000.00, 'Tusuk sate ayam dengan bumbu kacang.'),
    ('Soto Betawi', 20000.00, 'Soto daging sapi dengan santan.'),
    ('Rendang', 25000.00, 'Daging sapi dimasak dengan bumbu rendang khas Minang.'),
    ('Gado-Gado', 13000.00, 'Sayuran dengan bumbu kacang dan kerupuk.'),
    ('Ayam Goreng', 16000.00, 'Potongan ayam goreng renyah.'),
    ('Nasi Uduk', 10000.00, 'Nasi dengan bumbu rempah-rempah.'),
    ('Pecel Lele', 14000.00, 'Lele goreng dengan sambal kacang.'),
    ('Bakso', 12000.00, 'Bola-bola daging dengan kuah kaldu.');