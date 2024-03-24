function waitAndMove(redirectPgName, delayTime) {
    setTimeout(function () { leaveMe(redirectPgName) }, delayTime);
}


// Redirect to requested url   
function leaveMe(redirectPgName) {
    window.location = redirectPgName;
}