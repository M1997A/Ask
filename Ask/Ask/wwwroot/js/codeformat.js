


function addItem(isUserSignedIn) {

    var userId = $("#inputUserId").val();
    if (!userId || userId == "") {
        $("#btn-post").attr("data-target", "#myModal");
    } else {
        var temp = (((tinyMCE.get('textarea').getContent()).replace(/(&nbsp;)*/g, "")).replace(/(<p>)*/g, "")).replace(/<(\/)?p[^>]*>/g, "");
        var divMessage = $("#textareaValidation");
        if (temp.trim().length < 50) {
            divMessage.text("short answer");
        }
        else {




            const Answer = {
                QuestionId: $("#inputQuestionId").val(),
                Body: tinyMCE.get('textarea').getContent(),
                AppUserId: $("#inputUserId").val(),

            };

            $.ajax({
                type: "POST",
                accepts: "application/json",
                url: "/api/Answer",
                contentType: "application/json",
                data: JSON.stringify(Answer),
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Something went wrong!");
                },
                success: function (result) {
                    console.log(result);
                    var parent = $("#answerParent");
                    var firstChild = $("<div class='row'></div>");

                    var upvoter = $("<i title='this answer is useful' class='vote fa fa-angle-up fa-3x'></i>")
                        .on("click", function () { AnswerVoter(isUserSignedIn, result.answerId, userId, true) });
                    var upVoterBox = $("<div></div>").append(upvoter);

                    var voter = $("<div class='text-center' id=" + result.answerId + ">0</div>");

                    var downvoter = $("<i title='this answer is not useful' class='vote fa fa-angle-down fa-3x'></i>")
                        .on("click", function () { AnswerVoter(isUserSignedIn, result.answerId, userId, false) });
                    var downVoterBox = $("<div></div>").append(downvoter);

                    var rowFirstChild = $("<div class='col-1'>Vote</div>").append(upVoterBox).append(voter).append(downVoterBox);
                    var rowSecondChild = $("<div class='col-11'></div>");
                    var rowSecondChild_FirstChild = $("<div></div>");
                    var rowSecondChild_Code = $("<code class='prettyprint d-flex align-items-start bg-light'></code>");
                    var codeContent = result.body;
                    var codeChild = $("<div></div>").html(codeContent);

                    var logo = $("<div class='clearfix'></div>");
                    var logoChild = $("<div class='float-right q-u-info'><div>");
                    var logoChildFirst = $("<div class='q-u-time p-1 font-weight-light' style='height: 20px'></div>").text("answered 1 minutes ago");
                    var image = document.createElement("img");
                    var srcAttr = document.createAttribute("src");
                    srcAttr.value = result.imagePath;
                    image.setAttributeNode(srcAttr);
                    var logoChildSecond = $("<div class='m-2'></div>").append(image).append("&nbsp;" + result.userName);

                    parent.append(firstChild.append(rowFirstChild)
                        .append(rowSecondChild.append(rowSecondChild_FirstChild.append(rowSecondChild_Code.append(codeChild))
                        ).append(logo.append(logoChild.append(logoChildFirst).append(logoChildSecond)))));

                    tinyMCE.activeEditor.setContent('');
                }
            });
        }
    }
}


function QuestionVoter(isUserSigned, questionId, UserId, value) {

    if (isUserSigned == "True") {
        if (questionId && UserId) {
            const QuestionVoteVM = {
                QuestionId: questionId,
                AppUserId: UserId,
                Vote: value
            };

            $.ajax({
                type: "POST",
                accepts: "application/json",
                url: "/questionVote",
                contentType: "application/json",
                data: JSON.stringify(QuestionVoteVM),
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Something went wrong!");
                },
                success: function (result) {
                    $("#questionVote").text(result);
                }
            })
        } else {
            console.log("error-1");
        }
    } else {
        console.log("error-2");
    }
}
function AnswerVoter(isUserSigned, answerId, UserId, value) {
    if (isUserSigned == "True") {
        if (answerId && UserId) {
            const AnswerVoteVM = {
                AnswerId: answerId,
                AppUserId: UserId,
                Vote: value
            };

            $.ajax({
                type: "POST",
                accepts: "application/json",
                url: "/answerVote",
                contentType: "application/json",
                data: JSON.stringify(AnswerVoteVM),
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Something went wrong!");
                },
                success: function (result) {
                    $("#" + answerId).text(result);
                }
            })
        } else {
            console.log("error-1");
        }
    } else {
        console.log("error-2");
    }
}
function AddComment(UserId, QuestionId) {
    var comment = $("#textareaComment").val();
    if (UserId && QuestionId) {
        if (comment.trim().length < 2) {
            var message = "too short comment";
        } else if (comment.trim().length > 100) {
            var message = "too long comment";
        } else {
            const QuestionCommentVM = {
                Body: comment,
                QuestionId: QuestionId,
                AppUserId: UserId
            };
            $.ajax({
                type: "POST",
                accepts: "application/json",
                url: "/addQuestioComment",
                contentType: "application/json",
                data: JSON.stringify(QuestionCommentVM),
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Something went wrong!");
                },
                success: function (result) {
                   
                    var commentBox = $("#commentBox");
                    var parentDiv = $("<div style='font-size:small'>" + result.body + "</div>");
                    var userNameSapn = $('<span style="color:cornflowerblue" class="ml-2 font-weight-bold">' + result.userName + '</span>');
                    var timeSapn = $("<span class='ml-2'> commwnted 1 minutes ago</span>");
                    commentBox.append(parentDiv.append(userNameSapn).append(timeSapn)).append($("<hr />"));
                    $("#textareaComment").val("");

                    //$("#commentBox").append(`<div style='font-size:small'>
                    //`+ result.body + `<span style="color:cornflowerblue" class="ml-2 font-weight-bold">` + result.userName + `</span>
                    // <span class="ml-2"> commwnted 1 minutes ago</span></div> </hr>`);
                }
            });

        }

    }

}