CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;
DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'fin_app') THEN
        CREATE SCHEMA fin_app;
    END IF;
END $EF$;

CREATE TABLE fin_app.accounts (
    id uuid NOT NULL,
    nickname text NOT NULL,
    type integer NOT NULL,
    balance numeric NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    created_by uuid NOT NULL,
    updated_by uuid NOT NULL,
    CONSTRAINT pk_accounts PRIMARY KEY (id)
);

CREATE TABLE fin_app.categories (
    id uuid NOT NULL,
    name text NOT NULL,
    color text NOT NULL DEFAULT '#D3D3D3',
    primary_category_id uuid,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    created_by uuid NOT NULL,
    updated_by uuid NOT NULL,
    CONSTRAINT pk_categories PRIMARY KEY (id),
    CONSTRAINT fk_categories_categories_primary_category_id FOREIGN KEY (primary_category_id) REFERENCES fin_app.categories (id)
);

CREATE TABLE fin_app.transactions (
    id uuid NOT NULL,
    transaction_type integer NOT NULL,
    category_id uuid NOT NULL,
    account_id uuid NOT NULL,
    value numeric NOT NULL,
    remark character varying(400),
    date timestamp with time zone NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    created_by uuid NOT NULL,
    updated_by uuid NOT NULL,
    CONSTRAINT pk_transactions PRIMARY KEY (id),
    CONSTRAINT fk_transactions_account_account_id FOREIGN KEY (account_id) REFERENCES fin_app.accounts (id) ON DELETE RESTRICT,
    CONSTRAINT fk_transactions_category_category_id FOREIGN KEY (category_id) REFERENCES fin_app.categories (id) ON DELETE RESTRICT
);

CREATE INDEX ix_categories_primary_category_id ON fin_app.categories (primary_category_id);

CREATE INDEX ix_transactions_account_id ON fin_app.transactions (account_id);

CREATE INDEX ix_transactions_category_id ON fin_app.transactions (category_id);

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20241228234506_InitialMigration', '9.0.0');

COMMIT;


