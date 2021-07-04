alter proc spGetQuestionsDetails
as 
begin

select q.QuestionId, q.Title, q.Body,count(AnswerId) as AnswerCount,
((select count(*) from QuestionVotes qv where qv.QuestionId = q.QuestionId and qv.Vote = 1)
-(select count(*) from QuestionVotes qv where qv.QuestionId = q.QuestionId and qv.Vote = 0)) as Vote,
u.Id as UserId,u.UserName,u.ImagePath,q.PostedDate
from Questions q
left join Answers 
on q.QuestionId = Answers.QuestionId
left join AspNetUsers u
on q.AppUserId = u.Id
group by q.Title,q.Body,q.QuestionId,u.Id,u.UserName,u.ImagePath,q.PostedDate


end


select qt.QuestionTagId,qt.QuestionId,qt.TagId,t.Name 
from QuestionTags qt
join Tags t
on qt.TagId = t.TagId

select * from QuestionTags
select qt.QuestionTagId,qt.QuestionId,qt.TagId,t.Name 
from QuestionTags qt
join Tags t
on qt.TagId = t.TagId
select * from Questions
select * from Tags
select * from QuestionVotes where QuestionId = 1
select * from AspNetUsers 
insert into QuestionVotes values('da9903e1-f894-4b26-b7c2-2b9cda0624f3',1,1)
insert into QuestionVotes values('02abf5ed-44bb-4649-b575-92d8bd704193',1,0)

da9903e1-f894-4b26-b7c2-2b9cda0624f3
02abf5ed-44bb-4649-b575-92d8bd704193
d322bbee-1068-4942-9b89-738a1bb446a1


select q.QuestionId, q.Title, q.Body,count(AnswerId) as AnswerCount,
((select count(*) from QuestionVotes qv where qv.QuestionId = q.QuestionId and qv.Vote = 1)
-(select count(*) from QuestionVotes qv where qv.QuestionId = q.QuestionId and qv.Vote = 0)) as Vote,
u.Id as UserId,u.UserName,u.ImagePath
from Questions q
left join Answers 
on q.QuestionId = Answers.QuestionId
left join AspNetUsers u
on q.AppUserId = u.Id
group by q.Title,q.Body,q.QuestionId,u.Id,u.UserName,u.ImagePath



select * from QuestionVotes
select count(a.Vote) as post , count(b.Vote) as negt
from QuestionVotes a
join QuestionVotes b
on a.QuestionId = b.QuestionId
where a.Vote = 1 and b.Vote = 0

select ((select count(Vote) from QuestionVotes where Vote = 1 and QuestionId = 2) - (select count(Vote) from QuestionVotes where Vote = 0 and QuestionId = 2)) as Vote




