select q.QuestionId,q.Title,q.Body,q.PostedDate,q.AppUserId,u.UserName from Questions as q
join AspNetUsers as u 
on q.AppUserId = u.Id
where q.QuestionId = 1


select * from QuestionComments

insert into QuestionComments values('third Comment from me','d322bbee-1068-4942-9b89-738a1bb446a1',GetDate(),5)
insert into QuestionComments values('second long Comment from me to test this design glk ml;k msd kklk sdsl mm,msd al;kd ki llskl m,md ','d322bbee-1068-4942-9b89-738a1bb446a1',GetDate(),5)

insert into Answers values('<p><strong>what about this class</strong></p>  <p><code>public class AnswerComment</code></p>  <p><code>&nbsp; &nbsp; {</code></p>  <p><code>&nbsp; &nbsp; &nbsp; &nbsp; public long AnswerCommentId { get; set; }</code></p>  <p><code>&nbsp; &nbsp; &nbsp; &nbsp; public string Body { get; set; }</code></p>  <p><code>&nbsp; &nbsp; &nbsp; &nbsp; public string AppUserId { get; set; }</code></p>  <p><code>&nbsp; &nbsp; &nbsp; &nbsp; public AppUser AppUser { get; set; }</code></p>  <p><code>&nbsp; &nbsp; &nbsp; &nbsp; public DateTime CommentDate { get; set; }</code></p>  <p><code>&nbsp; &nbsp; &nbsp; &nbsp; public long AnswerId { get; set; }</code></p>  <p><code>&nbsp; &nbsp; &nbsp; &nbsp; public Answer Answer { get; set; }</code></p>  <p><code>&nbsp; &nbsp; }</code></p>',
GetDate(),5,'d322bbee-1068-4942-9b89-738a1bb446a1');

insert into Answers values('It is A C# Class',GetDate(),5,'d322bbee-1068-4942-9b89-738a1bb446a1');





select a.AnswerId,a.Body,a.CommentedDate,a.AppUserId,u.UserName from Answers as a
join AspNetUsers as u
on a.AppUserId = u.Id
where a.QuestionId = 1

select sa.SubAnswerId,sa.Body,sa.CommentedDate,sa.AnswerId,sa.AppUserId,u.UserName from SubAnswers as sa
join AspNetUsers as u
on sa.AppUserId = u.Id
where sa.AnswerId = 1

insert into SubAnswers(Body,CommentedDate,AnswerId,AppUserId) values('SubAnswer1 to Answer1',GetDate(),1,'d322bbee-1068-4942-9b89-738a1bb446a1')
insert into Answers(Body,CommentedDate,QuestionId,AppUserId) values('Ansewer-1 to Question-1',GETDATE(),1,'d322bbee-1068-4942-9b89-738a1bb446a1')
insert into Answers(Body,CommentedDate,QuestionId,AppUserId) values('Ansewer-2 to Question-2',GETDATE(),1,'d322bbee-1068-4942-9b89-738a1bb446a1')

insert into Questions values('Title',
'public class AnswerComment
    {
        public long AnswerCommentId { get; set; } </br>
        public string Body { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CommentDate { get; set; }
        public long AnswerId { get; set; }
        public Answer Answer { get; set; }
    }',
	GETDATE()
,'02abf5ed-44bb-4649-b575-92d8bd704193')

update  AspNetUsers set ImagePath = '/images/logo.png' where UserName = 'm3a'
select * from Questions
select * from SubAnswers
select * from Answers
select * from AspNetUsers
select q.QuestionId,q.Title,q.Body,q.PostedDate,q.AppUserId,u.UserName from Questions as q join AspNetUsers as u on q.AppUserId = u.Id where q.QuestionId = 1;

delete from QuestionVotes where id = 1
select * from AnswerVotes
select * from Answers