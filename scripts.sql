--------------------------------------------------------
--  File created - Wednesday-December-28-2016   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for View VIEW_ALLBOOK
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "RKO"."VIEW_ALLBOOK" ("BOOK_ID", "BOOK_NAME", "BOOK_QUANTITY", "BOOK_AVAILABLE", "BOOK_MODE", "AUTHOR_NAME", "PUBLISHER_NAME", "SELF_NAME") AS 
  select b.book_id,b.Book_Name, b.Book_quantity, b.book_available,b.book_mode, a.author_name, p.publisher_name, bs.self_name 
from book b,author a,publisher p,book_self bs where b.author_id=a.author_id and b.publisher_id=p.publisher_id and b.self_id=bs.self_id;
--------------------------------------------------------
--  DDL for View VIEW_BOOK
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "RKO"."VIEW_BOOK" ("BOOK_ID", "BOOK_MODE", "BOOK_NAME", "BOOK_QUANTITY", "BOOK_AVAILABLE", "AUTHOR_NAME", "PUBLISHER_NAME", "SELF_NAME") AS 
  select b.book_id,b.book_mode,b.Book_Name, b.Book_quantity, b.book_available, a.author_name, p.publisher_name, bs.self_name 
from book b,author a,publisher p,book_self bs where b.author_id=a.author_id and b.publisher_id=p.publisher_id and b.self_id=bs.self_id;
--------------------------------------------------------
--  DDL for View VIEW_ISSUE
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "RKO"."VIEW_ISSUE" ("MEMBER_ID", "ISSUE_ID", "ISSUE_START_DATE", "ISSUE_END_DATE", "ISSUE_STATUS", "MEMBER_NAME", "BOOK_AVAILABLE", "BOOK_ID", "BOOK_NAME", "MEMBER_ISSUE", "AUTHOR_NAME", "PUBLISHER_NAME") AS 
  SELECT m.member_id,i.issue_id,i.issue_start_date,i.issue_end_date,i.issue_status,m.member_name,b.book_available,b.book_id,b.book_name,m.member_issue,a.author_name,p.publisher_name 
FROM issue i,book b,member m,author a,publisher p where i.book_id=b.book_id and i.member_id=m.member_id and b.author_id=a.author_id and b.publisher_id=p.publisher_id and m.member_issue='Disable' and i.issue_status='Issued';
--------------------------------------------------------
--  DDL for View VIEW_ISSUESEARCH
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "RKO"."VIEW_ISSUESEARCH" ("MEMBER_ID", "ISSUE_ID", "ISSUE_START_DATE", "ISSUE_END_DATE", "ISSUE_STATUS", "MEMBER_NAME", "BOOK_AVAILABLE", "BOOK_ID", "BOOK_NAME", "MEMBER_ISSUE", "AUTHOR_NAME", "PUBLISHER_NAME") AS 
  SELECT m.member_id,i.issue_id,i.issue_start_date,i.issue_end_date,i.issue_status,m.member_name,b.book_available,b.book_id,b.book_name,m.member_issue,a.author_name,p.publisher_name 
FROM issue i,book b,member m,author a,publisher p where i.book_id=b.book_id and i.member_id=m.member_id and b.author_id=a.author_id and b.publisher_id=p.publisher_id;
--------------------------------------------------------
--  DDL for View VIEW_MEMBER
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "RKO"."VIEW_MEMBER" ("MEMBER_ID", "MEMBER_NAME", "MEMBER_MAIL", "MEMBER_CITY", "MEMBER_PHONE", "MEMBER_MODE", "MEMBER_ISSUE") AS 
  SELECT member_id,member_name,member_mail,member_city,member_phone,member_mode,member_issue
  FROM member;
--------------------------------------------------------
--  DDL for View VIEW_MEMBERMODE
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "RKO"."VIEW_MEMBERMODE" ("MEMBER_ID", "MEMBER_NAME", "MEMBER_MAIL", "MEMBER_CITY", "MEMBER_MODE") AS 
  select member_id,member_name,member_mail,member_city,member_mode
from member;
--------------------------------------------------------
--  DDL for View VIEW_SIMPLEISSUE
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "RKO"."VIEW_SIMPLEISSUE" ("ISSUE_ID", "ISSUE_STATUS", "ISSUE_START_DATE", "ISSUE_END_DATE", "MEMBER_NAME", "BOOK_NAME") AS 
  select i.issue_id,i.issue_status,i.issue_start_date,i.issue_end_date,m.member_name,b.book_name
from issue i,member m,book b where i.member_id=m.MEMBER_ID and i.BOOK_ID=b.BOOK_ID order by i.ISSUE_ID;
--------------------------------------------------------
--  DDL for Table ADMIN
--------------------------------------------------------

  CREATE TABLE "RKO"."ADMIN" 
   (	"USERNAME" VARCHAR2(50 BYTE), 
	"PASSWORD" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table AUTHOR
--------------------------------------------------------

  CREATE TABLE "RKO"."AUTHOR" 
   (	"AUTHOR_ID" NUMBER(38,0), 
	"AUTHOR_NAME" VARCHAR2(50 BYTE), 
	"AUTHOR_MAIL" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table BOOK
--------------------------------------------------------

  CREATE TABLE "RKO"."BOOK" 
   (	"BOOK_ID" NUMBER(38,0), 
	"BOOK_NAME" VARCHAR2(50 BYTE), 
	"BOOK_QUANTITY" NUMBER(38,0), 
	"BOOK_AVAILABLE" NUMBER(38,0), 
	"PUBLISHER_ID" NUMBER(38,0), 
	"SELF_ID" NUMBER, 
	"BOOK_MODE" VARCHAR2(20 BYTE), 
	"AUTHOR_ID" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table BOOK_SELF
--------------------------------------------------------

  CREATE TABLE "RKO"."BOOK_SELF" 
   (	"SELF_ID" NUMBER(38,0), 
	"SELF_NAME" VARCHAR2(50 BYTE), 
	"SELF_NO" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table ISSUE
--------------------------------------------------------

  CREATE TABLE "RKO"."ISSUE" 
   (	"ISSUE_ID" NUMBER(38,0), 
	"BOOK_ID" NUMBER(38,0), 
	"MEMBER_ID" NUMBER(38,0), 
	"ISSUE_START_DATE" DATE, 
	"ISSUE_END_DATE" DATE, 
	"ISSUE_STATUS" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table MEMBER
--------------------------------------------------------

  CREATE TABLE "RKO"."MEMBER" 
   (	"MEMBER_ID" NUMBER(38,0), 
	"MEMBER_NAME" VARCHAR2(50 BYTE), 
	"MEMBER_PHONE" VARCHAR2(50 BYTE), 
	"MEMBER_MAIL" VARCHAR2(50 BYTE), 
	"MEMBER_USERNAME" VARCHAR2(30 BYTE), 
	"MEMBER_PASSWORD" VARCHAR2(30 BYTE), 
	"MEMBER_MODE" VARCHAR2(20 BYTE), 
	"MEMBER_CITY" VARCHAR2(30 BYTE), 
	"MEMBER_ISSUE" VARCHAR2(30 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table PUBLISHER
--------------------------------------------------------

  CREATE TABLE "RKO"."PUBLISHER" 
   (	"PUBLISHER_ID" NUMBER(25,0), 
	"PUBLISHER_NAME" VARCHAR2(50 BYTE), 
	"PUBLISHER_MAIL" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Sequence AUTHOR_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RKO"."AUTHOR_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence BOOK_SELF_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RKO"."BOOK_SELF_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence Book_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RKO"."Book_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 61 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence ISSUE_STATUS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RKO"."ISSUE_STATUS_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence MEMBER_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RKO"."MEMBER_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PUBLISHER_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "RKO"."PUBLISHER_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
REM INSERTING into RKO.ADMIN
SET DEFINE OFF;
Insert into RKO.ADMIN (USERNAME,PASSWORD) values ('admin','admin');
REM INSERTING into RKO.AUTHOR
SET DEFINE OFF;
Insert into RKO.AUTHOR (AUTHOR_ID,AUTHOR_NAME,AUTHOR_MAIL) values (22,'James','james@gmail.com');
Insert into RKO.AUTHOR (AUTHOR_ID,AUTHOR_NAME,AUTHOR_MAIL) values (21,'Mike','Mike@gmail.com');
REM INSERTING into RKO.BOOK
SET DEFINE OFF;
Insert into RKO.BOOK (BOOK_ID,BOOK_NAME,BOOK_QUANTITY,BOOK_AVAILABLE,PUBLISHER_ID,SELF_ID,BOOK_MODE,AUTHOR_ID) values (41,'Absolution Gap',10,10,21,21,'Available',21);
Insert into RKO.BOOK (BOOK_ID,BOOK_NAME,BOOK_QUANTITY,BOOK_AVAILABLE,PUBLISHER_ID,SELF_ID,BOOK_MODE,AUTHOR_ID) values (42,'1776',20,20,22,22,'Available',22);
REM INSERTING into RKO.BOOK_SELF
SET DEFINE OFF;
Insert into RKO.BOOK_SELF (SELF_ID,SELF_NAME,SELF_NO) values (21,'Science','1-A');
Insert into RKO.BOOK_SELF (SELF_ID,SELF_NAME,SELF_NO) values (22,'History','2-A');
REM INSERTING into RKO.ISSUE
SET DEFINE OFF;
REM INSERTING into RKO.MEMBER
SET DEFINE OFF;
REM INSERTING into RKO.PUBLISHER
SET DEFINE OFF;
Insert into RKO.PUBLISHER (PUBLISHER_ID,PUBLISHER_NAME,PUBLISHER_MAIL) values (21,'Star','star@gmail.com');
Insert into RKO.PUBLISHER (PUBLISHER_ID,PUBLISHER_NAME,PUBLISHER_MAIL) values (22,'Asia','asia@gmail.com');
--------------------------------------------------------
--  DDL for Index AUTHOR_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."AUTHOR_PK" ON "RKO"."AUTHOR" ("AUTHOR_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index MEMBER_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."MEMBER_PK" ON "RKO"."MEMBER" ("MEMBER_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index ISSUE_STATUS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."ISSUE_STATUS_PK" ON "RKO"."ISSUE" ("ISSUE_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index ADMIN_CON
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."ADMIN_CON" ON "RKO"."ADMIN" ("USERNAME") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index AUTHOR_CON
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."AUTHOR_CON" ON "RKO"."AUTHOR" ("AUTHOR_NAME") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index PUBLISHER_CON
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."PUBLISHER_CON" ON "RKO"."PUBLISHER" ("PUBLISHER_NAME") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index MEMBER_CON
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."MEMBER_CON" ON "RKO"."MEMBER" ("MEMBER_USERNAME") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index PUBLISHER_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."PUBLISHER_PK" ON "RKO"."PUBLISHER" ("PUBLISHER_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index BOOK_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."BOOK_PK" ON "RKO"."BOOK" ("BOOK_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index BOOK_SELF_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."BOOK_SELF_PK" ON "RKO"."BOOK_SELF" ("SELF_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Index BOOK_SELF_CON
--------------------------------------------------------

  CREATE UNIQUE INDEX "RKO"."BOOK_SELF_CON" ON "RKO"."BOOK_SELF" ("SELF_NO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Trigger BI_AUTHOR
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RKO"."BI_AUTHOR" 
  before insert on "AUTHOR"               
  for each row  
begin   
  if :NEW."AUTHOR_ID" is null then 
    select "AUTHOR_SEQ".nextval into :NEW."AUTHOR_ID" from dual; 
  end if; 
end;
/
ALTER TRIGGER "RKO"."BI_AUTHOR" ENABLE;
--------------------------------------------------------
--  DDL for Trigger BI_BOOK
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RKO"."BI_BOOK" 
  before insert on "BOOK"               
  for each row  
begin   
  if :NEW."BOOK_ID" is null then 
    select "Book_SEQ".nextval into :NEW."BOOK_ID" from dual; 
  end if; 
end;
/
ALTER TRIGGER "RKO"."BI_BOOK" ENABLE;
--------------------------------------------------------
--  DDL for Trigger BI_BOOK_SELF
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RKO"."BI_BOOK_SELF" 
  before insert on "BOOK_SELF"               
  for each row  
begin   
  if :NEW."SELF_ID" is null then 
    select "BOOK_SELF_SEQ".nextval into :NEW."SELF_ID" from dual; 
  end if; 
end;
/
ALTER TRIGGER "RKO"."BI_BOOK_SELF" ENABLE;
--------------------------------------------------------
--  DDL for Trigger BI_ISSUE_STATUS
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RKO"."BI_ISSUE_STATUS" 
  before insert on "ISSUE"               
  for each row  
begin   
  if :NEW."ISSUE_ID" is null then 
    select "ISSUE_STATUS_SEQ".nextval into :NEW."ISSUE_ID" from dual; 
  end if; 
end;
/
ALTER TRIGGER "RKO"."BI_ISSUE_STATUS" ENABLE;
--------------------------------------------------------
--  DDL for Trigger BI_MEMBER
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RKO"."BI_MEMBER" 
  before insert on "MEMBER"               
  for each row  
begin   
  if :NEW."MEMBER_ID" is null then 
    select "MEMBER_SEQ".nextval into :NEW."MEMBER_ID" from dual; 
  end if; 
end;
/
ALTER TRIGGER "RKO"."BI_MEMBER" ENABLE;
--------------------------------------------------------
--  DDL for Trigger BI_PUBLISHER
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "RKO"."BI_PUBLISHER" 
  before insert on "PUBLISHER"               
  for each row  
begin   
  if :NEW."PUBLISHER_ID" is null then 
    select "PUBLISHER_SEQ".nextval into :NEW."PUBLISHER_ID" from dual; 
  end if; 
end;
/
ALTER TRIGGER "RKO"."BI_PUBLISHER" ENABLE;
--------------------------------------------------------
--  DDL for Procedure ADD_BOOKQTY
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."ADD_BOOKQTY" (bid in number, qty in number)
as
qt number;
begin 
qt:=add_qty(bid,qty);
update book set book_quantity=qt where book_id=bid;

qt:=add_avqty(bid,qty);
update book set book_available=qt where book_id=bid;
end;

/
--------------------------------------------------------
--  DDL for Procedure AUTHOR_DEL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."AUTHOR_DEL" (aid in number)
as
begin
delete from book where author_id=aid;
delete from author where author_id=aid;
end;

/
--------------------------------------------------------
--  DDL for Procedure BOOK_DEL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."BOOK_DEL" (bid in number)
as
begin
delete from issue where book_id=bid;
delete from book where book_id=bid;
end;

/
--------------------------------------------------------
--  DDL for Procedure ISSUE_BOOK
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."ISSUE_BOOK" (mid in number,bid in number,bavailable in number)
as
begin
update book set book_available=(bavailable-1) where book_id=bid;
update member set MEMBER_ISSUE='Disable' where member_id=mid;
end;

/
--------------------------------------------------------
--  DDL for Procedure MEMBER_DEL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."MEMBER_DEL" (mid in number)
as
begin
delete from issue where member_id=mid;
delete from member where member_id=mid;
end;

/
--------------------------------------------------------
--  DDL for Procedure PUBLISHER_DEL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."PUBLISHER_DEL" (pid in number)
as
begin
delete from book where publisher_id = pid;
delete from publisher where publisher_id = pid;
end;

/
--------------------------------------------------------
--  DDL for Procedure RETURN_BOOK
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."RETURN_BOOK" (mid in number,bid in number,iid in number,bavailable in number)
as
begin
update member set member_issue='Enable' where member_id=mid;
update book set book_available=(bavailable+1) where book_id=bid;
update issue set issue_status='Returned' where issue_id=iid;
end;

/
--------------------------------------------------------
--  DDL for Procedure SELF_DEL
--------------------------------------------------------
set define off;

  CREATE OR REPLACE PROCEDURE "RKO"."SELF_DEL" (sid in book_self.self_id%type)
as
begin 
delete from book where self_id=sid;
delete from book_self where self_id=sid;
end;

/
--------------------------------------------------------
--  DDL for Function ADD_AVQTY
--------------------------------------------------------

  CREATE OR REPLACE FUNCTION "RKO"."ADD_AVQTY" (bid in number, qty in number)
return number
as
t_qty number;

begin
select book_available into t_qty from book where book_id=bid;
t_qty:=t_qty+qty;
return t_qty;
end;

/
--------------------------------------------------------
--  DDL for Function ADD_QTY
--------------------------------------------------------

  CREATE OR REPLACE FUNCTION "RKO"."ADD_QTY" (bid in number, qty in number)
return number
as
t_qty number;

begin
select book_quantity into t_qty from book where book_id=bid;
t_qty:=t_qty+qty;
return t_qty;
end;

/
--------------------------------------------------------
--  Constraints for Table ISSUE
--------------------------------------------------------

  ALTER TABLE "RKO"."ISSUE" ADD CONSTRAINT "ISSUE_STATUS_PK" PRIMARY KEY ("ISSUE_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
--------------------------------------------------------
--  Constraints for Table BOOK_SELF
--------------------------------------------------------

  ALTER TABLE "RKO"."BOOK_SELF" ADD CONSTRAINT "BOOK_SELF_CON" UNIQUE ("SELF_NO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "RKO"."BOOK_SELF" ADD CONSTRAINT "BOOK_SELF_PK" PRIMARY KEY ("SELF_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
--------------------------------------------------------
--  Constraints for Table MEMBER
--------------------------------------------------------

  ALTER TABLE "RKO"."MEMBER" ADD CONSTRAINT "MEMBER_CON" UNIQUE ("MEMBER_USERNAME")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "RKO"."MEMBER" ADD CONSTRAINT "MEMBER_PK" PRIMARY KEY ("MEMBER_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
--------------------------------------------------------
--  Constraints for Table BOOK
--------------------------------------------------------

  ALTER TABLE "RKO"."BOOK" ADD CONSTRAINT "BOOK_PK" PRIMARY KEY ("BOOK_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
--------------------------------------------------------
--  Constraints for Table PUBLISHER
--------------------------------------------------------

  ALTER TABLE "RKO"."PUBLISHER" ADD CONSTRAINT "PUBLISHER_CON" UNIQUE ("PUBLISHER_NAME")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "RKO"."PUBLISHER" ADD CONSTRAINT "PUBLISHER_PK" PRIMARY KEY ("PUBLISHER_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "RKO"."PUBLISHER" MODIFY ("PUBLISHER_ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table AUTHOR
--------------------------------------------------------

  ALTER TABLE "RKO"."AUTHOR" ADD CONSTRAINT "AUTHOR_CON" UNIQUE ("AUTHOR_NAME")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "RKO"."AUTHOR" ADD CONSTRAINT "AUTHOR_PK" PRIMARY KEY ("AUTHOR_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
--------------------------------------------------------
--  Constraints for Table ADMIN
--------------------------------------------------------

  ALTER TABLE "RKO"."ADMIN" ADD CONSTRAINT "ADMIN_CON" PRIMARY KEY ("USERNAME")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM"  ENABLE;
  ALTER TABLE "RKO"."ADMIN" MODIFY ("PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "RKO"."ADMIN" MODIFY ("USERNAME" NOT NULL ENABLE);
--------------------------------------------------------
--  Ref Constraints for Table BOOK
--------------------------------------------------------

  ALTER TABLE "RKO"."BOOK" ADD CONSTRAINT "BOOK_CON" FOREIGN KEY ("SELF_ID")
	  REFERENCES "RKO"."BOOK_SELF" ("SELF_ID") ENABLE;
  ALTER TABLE "RKO"."BOOK" ADD CONSTRAINT "BOOK_CON1" FOREIGN KEY ("AUTHOR_ID")
	  REFERENCES "RKO"."AUTHOR" ("AUTHOR_ID") ENABLE;
  ALTER TABLE "RKO"."BOOK" ADD CONSTRAINT "BOOK_FK" FOREIGN KEY ("PUBLISHER_ID")
	  REFERENCES "RKO"."PUBLISHER" ("PUBLISHER_ID") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table ISSUE
--------------------------------------------------------

  ALTER TABLE "RKO"."ISSUE" ADD CONSTRAINT "ISSUE_STATUS_FK" FOREIGN KEY ("BOOK_ID")
	  REFERENCES "RKO"."BOOK" ("BOOK_ID") ENABLE;
  ALTER TABLE "RKO"."ISSUE" ADD CONSTRAINT "ISSUE_STATUS_FK2" FOREIGN KEY ("MEMBER_ID")
	  REFERENCES "RKO"."MEMBER" ("MEMBER_ID") ENABLE;
