namespace Notification;

public record NotificationDTO(
    Guid UserId,
    Guid ProblemId,
    Guid CommentId,
    Guid CommentatorId
);