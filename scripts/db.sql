--  Enums
CREATE TYPE job_state as ENUM('pending', 'accepted', 'active', 'inactive', 'failed', 'accomplished');
--  Users
DROP TABLE IF EXISTS "role";
CREATE TABLE "role"
(
    id SERIAL NOT NULL,
    role_name VARCHAR(150),
    role_description TEXT,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "user";
CREATE TABLE "user"
(
    id SERIAL NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50),
    email VARCHAR(150) NOT NULL,
    user_password VARCHAR(256) NOT NULL,
    user_role INT REFERENCES "role" NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Teams
DROP TABLE IF EXISTS "team";
CREATE TABLE "team"
(
    id SERIAL NOT NULL,
    team_name VARCHAR(150),
    team_description TEXT,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Messages
DROP TABLE IF EXISTS "message";
CREATE TABLE "message"(
    id SERIAL NOT NULL,
    to_user_fk INT REFERENCES "user" NOT NULL,
    from_user_fk INT REFERENCES "user" NOT NULL,
    content TEXT NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "comment";
CREATE TABLE "comment"(
    id SERIAL NOT NULL,
    content TEXT NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Jobs
DROP TABLE IF EXISTS "job_type";
CREATE TABLE "job_type"
(
    id SERIAL NOT NULL,
    type_name VARCHAR(150) NOT NULL,
    type_description TEXT,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "job";
CREATE TABLE "job"
(
    id SERIAL NOT NULL,
    job_name VARCHAR(150) NOT NULL,
    job_description TEXT NOT NULL,
    job_type INT REFERENCES "job_type" NOT NULL, 
    job_state job_state NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Posts
DROP TABLE IF EXISTS "post_type";
CREATE TABLE "post_type"
(
    id SERIAL NOT NULL,
    type_name VARCHAR(50),
    type_description TEXT,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "post";
CREATE TABLE "post"
(
    id SERIAL NOT NULL,
    title VARCHAR(150) NOT NULL,
    content TEXT NOT NULL,
    post_type INT REFERENCES "post_type" NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Goals
DROP TABLE IF EXISTS "goal";
CREATE TABLE "goal"
(
    id SERIAL NOT NULL,
    goal_start DATE NOT NULL,
    goal_end DATE NOT NULL,
    max_amount INT NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "sub_goal";
CREATE TABLE "sub_goal"
(
    id SERIAL NOT NULL,
    goal_start DATE NOT NULL,
    goal_end DATE NOT NULL,
    max_amount INT NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Products
DROP TABLE IF EXISTS "product_type";
CREATE TABLE "product_type"
(
    id SERIAL NOT NULL,
    type_name VARCHAR(50) NOT NULL,
    type_description TEXT,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "product";
CREATE TABLE "product"
(
    id SERIAL NOT NULL,
    product_name VARCHAR(150) NOT NULL, 
    product_description TEXT NOT NULL,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "campaign_type";
CREATE TABLE "campaign_type"
(
    id SERIAL NOT NULL,
    type_name VARCHAR(50) NOT NULL,
    type_description TEXT,
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Campaigns
DROP TABLE IF EXISTS "campaign";
CREATE TABLE "campaign"
(
    id SERIAL NOT NULL,
    campaign_name VARCHAR(150) NOT NULL,
    campaign_description TEXT,
    campaign_type INT REFERENCES "campaign_type",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  User joins
DROP TABLE IF EXISTS "user_post";
CREATE TABLE "user_post"
(
    id SERIAL NOT NULL,
    user_fk INT CONSTRAINT user_fk REFERENCES "user",
    post_fk INT CONSTRAINT post_fk REFERENCES "post",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "user_likes";
CREATE TABLE "user_likes"
(
    id SERIAL NOT NULL,
    user_fk INT CONSTRAINT user_fk REFERENCES "user",
    post_fk INT CONSTRAINT post_fk REFERENCES "post",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "user_comment";
CREATE TABLE "user_comment"
(
    id SERIAL NOT NULL,
    user_fk INT CONSTRAINT user_fk REFERENCES "user",
    comment_fk INT CONSTRAINT comment_fk REFERENCES "comment",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "user_team";
CREATE TABLE "user_team"
(
    id SERIAL NOT NULL,
    user_fk INT CONSTRAINT user_fk REFERENCES "user",
    team_fk INT CONSTRAINT team_fk REFERENCES "team",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "user_product";
CREATE TABLE "user_product"
(
    id SERIAL NOT NULL,
    user_fk INT CONSTRAINT user_fk REFERENCES "user",
    product_fk INT CONSTRAINT product_fk REFERENCES "product",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "user_campaign";
CREATE TABLE "user_campaign"
(
    id SERIAL NOT NULL,
    user_fk INT CONSTRAINT user_fk REFERENCES "user",
    campaign_fk INT CONSTRAINT campaign_fk REFERENCES "campaign",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Post joins
DROP TABLE IF EXISTS "post_comment";
CREATE TABLE "post_comment"
(
    id SERIAL NOT NULL,
    comment_fk INT CONSTRAINT comment_fk REFERENCES "comment",
    post_fk INT CONSTRAINT post_fk REFERENCES "post",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "post_product";
CREATE TABLE "post_product"
(
    id SERIAL NOT NULL,
    product_fk INT CONSTRAINT product_fk REFERENCES "product",
    post_fk INT CONSTRAINT post_fk REFERENCES "post",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Campaign joins
DROP TABLE IF EXISTS "campaign_goal";
CREATE TABLE "campaign_goal"
(
    id SERIAL NOT NULL,
    campaign_fk INT CONSTRAINT campaign_fk REFERENCES "campaign",
    goal_fk INT CONSTRAINT goal_fk REFERENCES "goal",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Product joins
DROP TABLE IF EXISTS "product_goal";
CREATE TABLE "product_goal"
(
    id SERIAL NOT NULL,
    product_fk INT CONSTRAINT product_fk REFERENCES "product",
    goal_fk INT CONSTRAINT goal_fk REFERENCES "goal",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "product_type";
CREATE TABLE "product_type"
(
    id SERIAL NOT NULL,
    product_fk INT CONSTRAINT product_fk REFERENCES "product",
    product_type_fk INT CONSTRAINT product_type_fk REFERENCES "product_type",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Teams & job joins
DROP TABLE IF EXISTS "team_job";
CREATE TABLE "team_job"
(
    id SERIAL NOT NULL,
    team_fk INT CONSTRAINT team_fk REFERENCES "team",
    job_fk INT CONSTRAINT job_fk REFERENCES "job",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "team_campaign";
CREATE TABLE "team_campaign"
(
    id SERIAL NOT NULL,
    team_fk INT CONSTRAINT team_fk REFERENCES "team",
    campaign_fk INT CONSTRAINT campaign_fk REFERENCES "campaign",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
DROP TABLE IF EXISTS "job_product";
CREATE TABLE "job_product"
(
    id SERIAL NOT NULL,
    job_fk INT CONSTRAINT job_fk REFERENCES "job",
    product_fk INT CONSTRAINT product_fk REFERENCES "product",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);
--  Goal & subgoal joins
DROP TABLE IF EXISTS "goal_sub_goal";
CREATE TABLE "goal_sub_goal"
(
    id SERIAL NOT NULL,
    goal_fk INT CONSTRAINT goal_fk  REFERENCES "goal",
    sub_goal_fk INT CONSTRAINT sub_goal_fk REFERENCES "sub_goal",
    created_on TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
);