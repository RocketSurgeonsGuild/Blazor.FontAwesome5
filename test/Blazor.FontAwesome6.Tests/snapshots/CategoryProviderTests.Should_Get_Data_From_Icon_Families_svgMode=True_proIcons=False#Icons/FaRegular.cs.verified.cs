using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Regular Icons
/// </summary>
public static partial class FaRegular
{
    private static SvgIcon? f_AddressBook;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-book?f=classic&amp;s=regular">Address Book</a>
    /// </summary>
    public static SvgIcon AddressBook => f_AddressBook ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "address-book", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-book?f=classic&amp;s=regular">Address Book</a>
    /// </summary>
    public static SvgIcon ContactBook => global::Someplace.FaRegular.AddressBook;
    private static SvgIcon? f_AddressCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-card?f=classic&amp;s=regular">Address Card</a>
    /// </summary>
    public static SvgIcon AddressCard => f_AddressCard ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "address-card", "[unicode]", 576, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-card?f=classic&amp;s=regular">Address Card</a>
    /// </summary>
    public static SvgIcon ContactCard => global::Someplace.FaRegular.AddressCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-card?f=classic&amp;s=regular">Address Card</a>
    /// </summary>
    public static SvgIcon Vcard => global::Someplace.FaRegular.AddressCard;
    private static SvgIcon? f_Bell;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/bell?f=classic&amp;s=regular">Bell</a>
    /// </summary>
    public static SvgIcon Bell => f_Bell ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "bell", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_BellSlash;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/bell-slash?f=classic&amp;s=regular">Bell Slash</a>
    /// </summary>
    public static SvgIcon BellSlash => f_BellSlash ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "bell-slash", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_Bookmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/bookmark?f=classic&amp;s=regular">Bookmark</a>
    /// </summary>
    public static SvgIcon Bookmark => f_Bookmark ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "bookmark", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_Building;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/building?f=classic&amp;s=regular">Building</a>
    /// </summary>
    public static SvgIcon Building => f_Building ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "building", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_Calendar;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar?f=classic&amp;s=regular">Calendar</a>
    /// </summary>
    public static SvgIcon Calendar => f_Calendar ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "calendar", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_CalendarCheck;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-check?f=classic&amp;s=regular">Calendar Check</a>
    /// </summary>
    public static SvgIcon CalendarCheck => f_CalendarCheck ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "calendar-check", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_CalendarDays;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-days?f=classic&amp;s=regular">Calendar Days</a>
    /// </summary>
    public static SvgIcon CalendarDays => f_CalendarDays ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "calendar-days", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-days?f=classic&amp;s=regular">Calendar Days</a>
    /// </summary>
    public static SvgIcon CalendarAlt => global::Someplace.FaRegular.CalendarDays;
    private static SvgIcon? f_CalendarMinus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-minus?f=classic&amp;s=regular">Calendar Minus</a>
    /// </summary>
    public static SvgIcon CalendarMinus => f_CalendarMinus ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "calendar-minus", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_CalendarPlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-plus?f=classic&amp;s=regular">Calendar Plus</a>
    /// </summary>
    public static SvgIcon CalendarPlus => f_CalendarPlus ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "calendar-plus", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_CalendarXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-xmark?f=classic&amp;s=regular">Calendar Xmark</a>
    /// </summary>
    public static SvgIcon CalendarXmark => f_CalendarXmark ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "calendar-xmark", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-xmark?f=classic&amp;s=regular">Calendar Xmark</a>
    /// </summary>
    public static SvgIcon CalendarTimes => global::Someplace.FaRegular.CalendarXmark;
    private static SvgIcon? f_ChartBar;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chart-bar?f=classic&amp;s=regular">Chart Bar</a>
    /// </summary>
    public static SvgIcon ChartBar => f_ChartBar ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "chart-bar", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chart-bar?f=classic&amp;s=regular">Chart Bar</a>
    /// </summary>
    public static SvgIcon BarChart => global::Someplace.FaRegular.ChartBar;
    private static SvgIcon? f_ChessBishop;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-bishop?f=classic&amp;s=regular">Chess Bishop</a>
    /// </summary>
    public static SvgIcon ChessBishop => f_ChessBishop ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "chess-bishop", "[unicode]", 320, 512, "[path]");
    private static SvgIcon? f_ChessKing;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-king?f=classic&amp;s=regular">Chess King</a>
    /// </summary>
    public static SvgIcon ChessKing => f_ChessKing ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "chess-king", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_ChessKnight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-knight?f=classic&amp;s=regular">Chess Knight</a>
    /// </summary>
    public static SvgIcon ChessKnight => f_ChessKnight ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "chess-knight", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_ChessPawn;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-pawn?f=classic&amp;s=regular">Chess Pawn</a>
    /// </summary>
    public static SvgIcon ChessPawn => f_ChessPawn ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "chess-pawn", "[unicode]", 320, 512, "[path]");
    private static SvgIcon? f_ChessQueen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-queen?f=classic&amp;s=regular">Chess Queen</a>
    /// </summary>
    public static SvgIcon ChessQueen => f_ChessQueen ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "chess-queen", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_ChessRook;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-rook?f=classic&amp;s=regular">Chess Rook</a>
    /// </summary>
    public static SvgIcon ChessRook => f_ChessRook ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "chess-rook", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_Circle;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle?f=classic&amp;s=regular">Circle</a>
    /// </summary>
    public static SvgIcon Circle => f_Circle ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_CircleCheck;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-check?f=classic&amp;s=regular">Circle Check</a>
    /// </summary>
    public static SvgIcon CircleCheck => f_CircleCheck ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-check", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-check?f=classic&amp;s=regular">Circle Check</a>
    /// </summary>
    public static SvgIcon CheckCircle => global::Someplace.FaRegular.CircleCheck;
    private static SvgIcon? f_CircleDot;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-dot?f=classic&amp;s=regular">Circle Dot</a>
    /// </summary>
    public static SvgIcon CircleDot => f_CircleDot ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-dot", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-dot?f=classic&amp;s=regular">Circle Dot</a>
    /// </summary>
    public static SvgIcon DotCircle => global::Someplace.FaRegular.CircleDot;
    private static SvgIcon? f_CircleDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-down?f=classic&amp;s=regular">Circle Down</a>
    /// </summary>
    public static SvgIcon CircleDown => f_CircleDown ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-down", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-down?f=classic&amp;s=regular">Circle Down</a>
    /// </summary>
    public static SvgIcon ArrowAltCircleDown => global::Someplace.FaRegular.CircleDown;
    private static SvgIcon? f_CircleLeft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-left?f=classic&amp;s=regular">Circle Left</a>
    /// </summary>
    public static SvgIcon CircleLeft => f_CircleLeft ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-left", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-left?f=classic&amp;s=regular">Circle Left</a>
    /// </summary>
    public static SvgIcon ArrowAltCircleLeft => global::Someplace.FaRegular.CircleLeft;
    private static SvgIcon? f_CirclePause;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-pause?f=classic&amp;s=regular">Circle Pause</a>
    /// </summary>
    public static SvgIcon CirclePause => f_CirclePause ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-pause", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-pause?f=classic&amp;s=regular">Circle Pause</a>
    /// </summary>
    public static SvgIcon PauseCircle => global::Someplace.FaRegular.CirclePause;
    private static SvgIcon? f_CirclePlay;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-play?f=classic&amp;s=regular">Circle Play</a>
    /// </summary>
    public static SvgIcon CirclePlay => f_CirclePlay ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-play", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-play?f=classic&amp;s=regular">Circle Play</a>
    /// </summary>
    public static SvgIcon PlayCircle => global::Someplace.FaRegular.CirclePlay;
    private static SvgIcon? f_CircleQuestion;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-question?f=classic&amp;s=regular">Circle Question</a>
    /// </summary>
    public static SvgIcon CircleQuestion => f_CircleQuestion ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-question", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-question?f=classic&amp;s=regular">Circle Question</a>
    /// </summary>
    public static SvgIcon QuestionCircle => global::Someplace.FaRegular.CircleQuestion;
    private static SvgIcon? f_CircleRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-right?f=classic&amp;s=regular">Circle Right</a>
    /// </summary>
    public static SvgIcon CircleRight => f_CircleRight ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-right", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-right?f=classic&amp;s=regular">Circle Right</a>
    /// </summary>
    public static SvgIcon ArrowAltCircleRight => global::Someplace.FaRegular.CircleRight;
    private static SvgIcon? f_CircleStop;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-stop?f=classic&amp;s=regular">Circle Stop</a>
    /// </summary>
    public static SvgIcon CircleStop => f_CircleStop ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-stop", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-stop?f=classic&amp;s=regular">Circle Stop</a>
    /// </summary>
    public static SvgIcon StopCircle => global::Someplace.FaRegular.CircleStop;
    private static SvgIcon? f_CircleUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-up?f=classic&amp;s=regular">Circle Up</a>
    /// </summary>
    public static SvgIcon CircleUp => f_CircleUp ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-up", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-up?f=classic&amp;s=regular">Circle Up</a>
    /// </summary>
    public static SvgIcon ArrowAltCircleUp => global::Someplace.FaRegular.CircleUp;
    private static SvgIcon? f_CircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-user?f=classic&amp;s=regular">Circle User</a>
    /// </summary>
    public static SvgIcon CircleUser => f_CircleUser ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-user", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-user?f=classic&amp;s=regular">Circle User</a>
    /// </summary>
    public static SvgIcon UserCircle => global::Someplace.FaRegular.CircleUser;
    private static SvgIcon? f_CircleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-xmark?f=classic&amp;s=regular">Circle Xmark</a>
    /// </summary>
    public static SvgIcon CircleXmark => f_CircleXmark ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "circle-xmark", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-xmark?f=classic&amp;s=regular">Circle Xmark</a>
    /// </summary>
    public static SvgIcon TimesCircle => global::Someplace.FaRegular.CircleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-xmark?f=classic&amp;s=regular">Circle Xmark</a>
    /// </summary>
    public static SvgIcon XmarkCircle => global::Someplace.FaRegular.CircleXmark;
    private static SvgIcon? f_Clipboard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clipboard?f=classic&amp;s=regular">Clipboard</a>
    /// </summary>
    public static SvgIcon Clipboard => f_Clipboard ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "clipboard", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_Clock;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clock?f=classic&amp;s=regular">Clock</a>
    /// </summary>
    public static SvgIcon Clock => f_Clock ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "clock", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clock?f=classic&amp;s=regular">Clock</a>
    /// </summary>
    public static SvgIcon ClockFour => global::Someplace.FaRegular.Clock;
    private static SvgIcon? f_Clone;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clone?f=classic&amp;s=regular">Clone</a>
    /// </summary>
    public static SvgIcon Clone => f_Clone ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "clone", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_ClosedCaptioning;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/closed-captioning?f=classic&amp;s=regular">Closed Captioning</a>
    /// </summary>
    public static SvgIcon ClosedCaptioning => f_ClosedCaptioning ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "closed-captioning", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_Comment;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comment?f=classic&amp;s=regular">Comment</a>
    /// </summary>
    public static SvgIcon Comment => f_Comment ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "comment", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_CommentDots;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comment-dots?f=classic&amp;s=regular">Comment Dots</a>
    /// </summary>
    public static SvgIcon CommentDots => f_CommentDots ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "comment-dots", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comment-dots?f=classic&amp;s=regular">Comment Dots</a>
    /// </summary>
    public static SvgIcon Commenting => global::Someplace.FaRegular.CommentDots;
    private static SvgIcon? f_Comments;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comments?f=classic&amp;s=regular">Comments</a>
    /// </summary>
    public static SvgIcon Comments => f_Comments ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "comments", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_Compass;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/compass?f=classic&amp;s=regular">Compass</a>
    /// </summary>
    public static SvgIcon Compass => f_Compass ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "compass", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_Copy;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/copy?f=classic&amp;s=regular">Copy</a>
    /// </summary>
    public static SvgIcon Copy => f_Copy ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "copy", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_Copyright;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/copyright?f=classic&amp;s=regular">Copyright</a>
    /// </summary>
    public static SvgIcon Copyright => f_Copyright ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "copyright", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_CreditCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/credit-card?f=classic&amp;s=regular">Credit Card</a>
    /// </summary>
    public static SvgIcon CreditCard => f_CreditCard ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "credit-card", "[unicode]", 576, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/credit-card?f=classic&amp;s=regular">Credit Card</a>
    /// </summary>
    public static SvgIcon CreditCardAlt => global::Someplace.FaRegular.CreditCard;
    private static SvgIcon? f_Envelope;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/envelope?f=classic&amp;s=regular">Envelope</a>
    /// </summary>
    public static SvgIcon Envelope => f_Envelope ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "envelope", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_EnvelopeOpen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/envelope-open?f=classic&amp;s=regular">Envelope Open</a>
    /// </summary>
    public static SvgIcon EnvelopeOpen => f_EnvelopeOpen ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "envelope-open", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_Eye;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/eye?f=classic&amp;s=regular">Eye</a>
    /// </summary>
    public static SvgIcon Eye => f_Eye ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "eye", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_EyeSlash;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/eye-slash?f=classic&amp;s=regular">Eye Slash</a>
    /// </summary>
    public static SvgIcon EyeSlash => f_EyeSlash ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "eye-slash", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_FaceAngry;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-angry?f=classic&amp;s=regular">Face Angry</a>
    /// </summary>
    public static SvgIcon FaceAngry => f_FaceAngry ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-angry", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-angry?f=classic&amp;s=regular">Face Angry</a>
    /// </summary>
    public static SvgIcon Angry => global::Someplace.FaRegular.FaceAngry;
    private static SvgIcon? f_FaceDizzy;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-dizzy?f=classic&amp;s=regular">Face Dizzy</a>
    /// </summary>
    public static SvgIcon FaceDizzy => f_FaceDizzy ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-dizzy", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-dizzy?f=classic&amp;s=regular">Face Dizzy</a>
    /// </summary>
    public static SvgIcon Dizzy => global::Someplace.FaRegular.FaceDizzy;
    private static SvgIcon? f_FaceFlushed;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-flushed?f=classic&amp;s=regular">Face Flushed</a>
    /// </summary>
    public static SvgIcon FaceFlushed => f_FaceFlushed ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-flushed", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-flushed?f=classic&amp;s=regular">Face Flushed</a>
    /// </summary>
    public static SvgIcon Flushed => global::Someplace.FaRegular.FaceFlushed;
    private static SvgIcon? f_FaceFrown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown?f=classic&amp;s=regular">Face Frown</a>
    /// </summary>
    public static SvgIcon FaceFrown => f_FaceFrown ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-frown", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown?f=classic&amp;s=regular">Face Frown</a>
    /// </summary>
    public static SvgIcon Frown => global::Someplace.FaRegular.FaceFrown;
    private static SvgIcon? f_FaceFrownOpen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown-open?f=classic&amp;s=regular">Face Frown Open</a>
    /// </summary>
    public static SvgIcon FaceFrownOpen => f_FaceFrownOpen ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-frown-open", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown-open?f=classic&amp;s=regular">Face Frown Open</a>
    /// </summary>
    public static SvgIcon FrownOpen => global::Someplace.FaRegular.FaceFrownOpen;
    private static SvgIcon? f_FaceGrimace;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grimace?f=classic&amp;s=regular">Face Grimace</a>
    /// </summary>
    public static SvgIcon FaceGrimace => f_FaceGrimace ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grimace", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grimace?f=classic&amp;s=regular">Face Grimace</a>
    /// </summary>
    public static SvgIcon Grimace => global::Someplace.FaRegular.FaceGrimace;
    private static SvgIcon? f_FaceGrin;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin?f=classic&amp;s=regular">Face Grin</a>
    /// </summary>
    public static SvgIcon FaceGrin => f_FaceGrin ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin?f=classic&amp;s=regular">Face Grin</a>
    /// </summary>
    public static SvgIcon Grin => global::Someplace.FaRegular.FaceGrin;
    private static SvgIcon? f_FaceGrinBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam?f=classic&amp;s=regular">Face Grin Beam</a>
    /// </summary>
    public static SvgIcon FaceGrinBeam => f_FaceGrinBeam ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-beam", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam?f=classic&amp;s=regular">Face Grin Beam</a>
    /// </summary>
    public static SvgIcon GrinBeam => global::Someplace.FaRegular.FaceGrinBeam;
    private static SvgIcon? f_FaceGrinBeamSweat;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam-sweat?f=classic&amp;s=regular">Face Grin Beam Sweat</a>
    /// </summary>
    public static SvgIcon FaceGrinBeamSweat => f_FaceGrinBeamSweat ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-beam-sweat", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam-sweat?f=classic&amp;s=regular">Face Grin Beam Sweat</a>
    /// </summary>
    public static SvgIcon GrinBeamSweat => global::Someplace.FaRegular.FaceGrinBeamSweat;
    private static SvgIcon? f_FaceGrinHearts;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-hearts?f=classic&amp;s=regular">Face Grin Hearts</a>
    /// </summary>
    public static SvgIcon FaceGrinHearts => f_FaceGrinHearts ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-hearts", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-hearts?f=classic&amp;s=regular">Face Grin Hearts</a>
    /// </summary>
    public static SvgIcon GrinHearts => global::Someplace.FaRegular.FaceGrinHearts;
    private static SvgIcon? f_FaceGrinSquint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint?f=classic&amp;s=regular">Face Grin Squint</a>
    /// </summary>
    public static SvgIcon FaceGrinSquint => f_FaceGrinSquint ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-squint", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint?f=classic&amp;s=regular">Face Grin Squint</a>
    /// </summary>
    public static SvgIcon GrinSquint => global::Someplace.FaRegular.FaceGrinSquint;
    private static SvgIcon? f_FaceGrinSquintTears;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint-tears?f=classic&amp;s=regular">Face Grin Squint Tears</a>
    /// </summary>
    public static SvgIcon FaceGrinSquintTears => f_FaceGrinSquintTears ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-squint-tears", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint-tears?f=classic&amp;s=regular">Face Grin Squint Tears</a>
    /// </summary>
    public static SvgIcon GrinSquintTears => global::Someplace.FaRegular.FaceGrinSquintTears;
    private static SvgIcon? f_FaceGrinStars;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-stars?f=classic&amp;s=regular">Face Grin Stars</a>
    /// </summary>
    public static SvgIcon FaceGrinStars => f_FaceGrinStars ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-stars", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-stars?f=classic&amp;s=regular">Face Grin Stars</a>
    /// </summary>
    public static SvgIcon GrinStars => global::Someplace.FaRegular.FaceGrinStars;
    private static SvgIcon? f_FaceGrinTears;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tears?f=classic&amp;s=regular">Face Grin Tears</a>
    /// </summary>
    public static SvgIcon FaceGrinTears => f_FaceGrinTears ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-tears", "[unicode]", 640, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tears?f=classic&amp;s=regular">Face Grin Tears</a>
    /// </summary>
    public static SvgIcon GrinTears => global::Someplace.FaRegular.FaceGrinTears;
    private static SvgIcon? f_FaceGrinTongue;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue?f=classic&amp;s=regular">Face Grin Tongue</a>
    /// </summary>
    public static SvgIcon FaceGrinTongue => f_FaceGrinTongue ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-tongue", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue?f=classic&amp;s=regular">Face Grin Tongue</a>
    /// </summary>
    public static SvgIcon GrinTongue => global::Someplace.FaRegular.FaceGrinTongue;
    private static SvgIcon? f_FaceGrinTongueSquint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-squint?f=classic&amp;s=regular">Face Grin Tongue Squint</a>
    /// </summary>
    public static SvgIcon FaceGrinTongueSquint => f_FaceGrinTongueSquint ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-tongue-squint", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-squint?f=classic&amp;s=regular">Face Grin Tongue Squint</a>
    /// </summary>
    public static SvgIcon GrinTongueSquint => global::Someplace.FaRegular.FaceGrinTongueSquint;
    private static SvgIcon? f_FaceGrinTongueWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-wink?f=classic&amp;s=regular">Face Grin Tongue Wink</a>
    /// </summary>
    public static SvgIcon FaceGrinTongueWink => f_FaceGrinTongueWink ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-tongue-wink", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-wink?f=classic&amp;s=regular">Face Grin Tongue Wink</a>
    /// </summary>
    public static SvgIcon GrinTongueWink => global::Someplace.FaRegular.FaceGrinTongueWink;
    private static SvgIcon? f_FaceGrinWide;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wide?f=classic&amp;s=regular">Face Grin Wide</a>
    /// </summary>
    public static SvgIcon FaceGrinWide => f_FaceGrinWide ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-wide", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wide?f=classic&amp;s=regular">Face Grin Wide</a>
    /// </summary>
    public static SvgIcon GrinAlt => global::Someplace.FaRegular.FaceGrinWide;
    private static SvgIcon? f_FaceGrinWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wink?f=classic&amp;s=regular">Face Grin Wink</a>
    /// </summary>
    public static SvgIcon FaceGrinWink => f_FaceGrinWink ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-grin-wink", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wink?f=classic&amp;s=regular">Face Grin Wink</a>
    /// </summary>
    public static SvgIcon GrinWink => global::Someplace.FaRegular.FaceGrinWink;
    private static SvgIcon? f_FaceKiss;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss?f=classic&amp;s=regular">Face Kiss</a>
    /// </summary>
    public static SvgIcon FaceKiss => f_FaceKiss ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-kiss", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss?f=classic&amp;s=regular">Face Kiss</a>
    /// </summary>
    public static SvgIcon Kiss => global::Someplace.FaRegular.FaceKiss;
    private static SvgIcon? f_FaceKissBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-beam?f=classic&amp;s=regular">Face Kiss Beam</a>
    /// </summary>
    public static SvgIcon FaceKissBeam => f_FaceKissBeam ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-kiss-beam", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-beam?f=classic&amp;s=regular">Face Kiss Beam</a>
    /// </summary>
    public static SvgIcon KissBeam => global::Someplace.FaRegular.FaceKissBeam;
    private static SvgIcon? f_FaceKissWinkHeart;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-wink-heart?f=classic&amp;s=regular">Face Kiss Wink Heart</a>
    /// </summary>
    public static SvgIcon FaceKissWinkHeart => f_FaceKissWinkHeart ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-kiss-wink-heart", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-wink-heart?f=classic&amp;s=regular">Face Kiss Wink Heart</a>
    /// </summary>
    public static SvgIcon KissWinkHeart => global::Someplace.FaRegular.FaceKissWinkHeart;
    private static SvgIcon? f_FaceLaugh;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh?f=classic&amp;s=regular">Face Laugh</a>
    /// </summary>
    public static SvgIcon FaceLaugh => f_FaceLaugh ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-laugh", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh?f=classic&amp;s=regular">Face Laugh</a>
    /// </summary>
    public static SvgIcon Laugh => global::Someplace.FaRegular.FaceLaugh;
    private static SvgIcon? f_FaceLaughBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-beam?f=classic&amp;s=regular">Face Laugh Beam</a>
    /// </summary>
    public static SvgIcon FaceLaughBeam => f_FaceLaughBeam ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-laugh-beam", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-beam?f=classic&amp;s=regular">Face Laugh Beam</a>
    /// </summary>
    public static SvgIcon LaughBeam => global::Someplace.FaRegular.FaceLaughBeam;
    private static SvgIcon? f_FaceLaughSquint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-squint?f=classic&amp;s=regular">Face Laugh Squint</a>
    /// </summary>
    public static SvgIcon FaceLaughSquint => f_FaceLaughSquint ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-laugh-squint", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-squint?f=classic&amp;s=regular">Face Laugh Squint</a>
    /// </summary>
    public static SvgIcon LaughSquint => global::Someplace.FaRegular.FaceLaughSquint;
    private static SvgIcon? f_FaceLaughWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-wink?f=classic&amp;s=regular">Face Laugh Wink</a>
    /// </summary>
    public static SvgIcon FaceLaughWink => f_FaceLaughWink ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-laugh-wink", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-wink?f=classic&amp;s=regular">Face Laugh Wink</a>
    /// </summary>
    public static SvgIcon LaughWink => global::Someplace.FaRegular.FaceLaughWink;
    private static SvgIcon? f_FaceMeh;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh?f=classic&amp;s=regular">Face Meh</a>
    /// </summary>
    public static SvgIcon FaceMeh => f_FaceMeh ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-meh", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh?f=classic&amp;s=regular">Face Meh</a>
    /// </summary>
    public static SvgIcon Meh => global::Someplace.FaRegular.FaceMeh;
    private static SvgIcon? f_FaceMehBlank;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh-blank?f=classic&amp;s=regular">Face Meh Blank</a>
    /// </summary>
    public static SvgIcon FaceMehBlank => f_FaceMehBlank ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-meh-blank", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh-blank?f=classic&amp;s=regular">Face Meh Blank</a>
    /// </summary>
    public static SvgIcon MehBlank => global::Someplace.FaRegular.FaceMehBlank;
    private static SvgIcon? f_FaceRollingEyes;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-rolling-eyes?f=classic&amp;s=regular">Face Rolling Eyes</a>
    /// </summary>
    public static SvgIcon FaceRollingEyes => f_FaceRollingEyes ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-rolling-eyes", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-rolling-eyes?f=classic&amp;s=regular">Face Rolling Eyes</a>
    /// </summary>
    public static SvgIcon MehRollingEyes => global::Someplace.FaRegular.FaceRollingEyes;
    private static SvgIcon? f_FaceSadCry;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-cry?f=classic&amp;s=regular">Face Sad Cry</a>
    /// </summary>
    public static SvgIcon FaceSadCry => f_FaceSadCry ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-sad-cry", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-cry?f=classic&amp;s=regular">Face Sad Cry</a>
    /// </summary>
    public static SvgIcon SadCry => global::Someplace.FaRegular.FaceSadCry;
    private static SvgIcon? f_FaceSadTear;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-tear?f=classic&amp;s=regular">Face Sad Tear</a>
    /// </summary>
    public static SvgIcon FaceSadTear => f_FaceSadTear ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-sad-tear", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-tear?f=classic&amp;s=regular">Face Sad Tear</a>
    /// </summary>
    public static SvgIcon SadTear => global::Someplace.FaRegular.FaceSadTear;
    private static SvgIcon? f_FaceSmile;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile?f=classic&amp;s=regular">Face Smile</a>
    /// </summary>
    public static SvgIcon FaceSmile => f_FaceSmile ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-smile", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile?f=classic&amp;s=regular">Face Smile</a>
    /// </summary>
    public static SvgIcon Smile => global::Someplace.FaRegular.FaceSmile;
    private static SvgIcon? f_FaceSmileBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-beam?f=classic&amp;s=regular">Face Smile Beam</a>
    /// </summary>
    public static SvgIcon FaceSmileBeam => f_FaceSmileBeam ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-smile-beam", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-beam?f=classic&amp;s=regular">Face Smile Beam</a>
    /// </summary>
    public static SvgIcon SmileBeam => global::Someplace.FaRegular.FaceSmileBeam;
    private static SvgIcon? f_FaceSmileWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-wink?f=classic&amp;s=regular">Face Smile Wink</a>
    /// </summary>
    public static SvgIcon FaceSmileWink => f_FaceSmileWink ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-smile-wink", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-wink?f=classic&amp;s=regular">Face Smile Wink</a>
    /// </summary>
    public static SvgIcon SmileWink => global::Someplace.FaRegular.FaceSmileWink;
    private static SvgIcon? f_FaceSurprise;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-surprise?f=classic&amp;s=regular">Face Surprise</a>
    /// </summary>
    public static SvgIcon FaceSurprise => f_FaceSurprise ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-surprise", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-surprise?f=classic&amp;s=regular">Face Surprise</a>
    /// </summary>
    public static SvgIcon Surprise => global::Someplace.FaRegular.FaceSurprise;
    private static SvgIcon? f_FaceTired;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-tired?f=classic&amp;s=regular">Face Tired</a>
    /// </summary>
    public static SvgIcon FaceTired => f_FaceTired ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "face-tired", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-tired?f=classic&amp;s=regular">Face Tired</a>
    /// </summary>
    public static SvgIcon Tired => global::Someplace.FaRegular.FaceTired;
    private static SvgIcon? f_File;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file?f=classic&amp;s=regular">File</a>
    /// </summary>
    public static SvgIcon File => f_File ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileAudio;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-audio?f=classic&amp;s=regular">File Audio</a>
    /// </summary>
    public static SvgIcon FileAudio => f_FileAudio ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-audio", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileCode;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-code?f=classic&amp;s=regular">File Code</a>
    /// </summary>
    public static SvgIcon FileCode => f_FileCode ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-code", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileExcel;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-excel?f=classic&amp;s=regular">File Excel</a>
    /// </summary>
    public static SvgIcon FileExcel => f_FileExcel ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-excel", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileImage;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-image?f=classic&amp;s=regular">File Image</a>
    /// </summary>
    public static SvgIcon FileImage => f_FileImage ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-image", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileLines;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-lines?f=classic&amp;s=regular">File Lines</a>
    /// </summary>
    public static SvgIcon FileLines => f_FileLines ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-lines", "[unicode]", 384, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-lines?f=classic&amp;s=regular">File Lines</a>
    /// </summary>
    public static SvgIcon FileAlt => global::Someplace.FaRegular.FileLines;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-lines?f=classic&amp;s=regular">File Lines</a>
    /// </summary>
    public static SvgIcon FileText => global::Someplace.FaRegular.FileLines;
    private static SvgIcon? f_FilePdf;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-pdf?f=classic&amp;s=regular">File Pdf</a>
    /// </summary>
    public static SvgIcon FilePdf => f_FilePdf ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-pdf", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_FilePowerpoint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-powerpoint?f=classic&amp;s=regular">File Powerpoint</a>
    /// </summary>
    public static SvgIcon FilePowerpoint => f_FilePowerpoint ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-powerpoint", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileVideo;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-video?f=classic&amp;s=regular">File Video</a>
    /// </summary>
    public static SvgIcon FileVideo => f_FileVideo ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-video", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileWord;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-word?f=classic&amp;s=regular">File Word</a>
    /// </summary>
    public static SvgIcon FileWord => f_FileWord ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-word", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_FileZipper;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-zipper?f=classic&amp;s=regular">File Zipper</a>
    /// </summary>
    public static SvgIcon FileZipper => f_FileZipper ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "file-zipper", "[unicode]", 384, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-zipper?f=classic&amp;s=regular">File Zipper</a>
    /// </summary>
    public static SvgIcon FileArchive => global::Someplace.FaRegular.FileZipper;
    private static SvgIcon? f_Flag;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/flag?f=classic&amp;s=regular">Flag</a>
    /// </summary>
    public static SvgIcon Flag => f_Flag ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "flag", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_FloppyDisk;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/floppy-disk?f=classic&amp;s=regular">Floppy Disk</a>
    /// </summary>
    public static SvgIcon FloppyDisk => f_FloppyDisk ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "floppy-disk", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/floppy-disk?f=classic&amp;s=regular">Floppy Disk</a>
    /// </summary>
    public static SvgIcon Save => global::Someplace.FaRegular.FloppyDisk;
    private static SvgIcon? f_Folder;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder?f=classic&amp;s=regular">Folder</a>
    /// </summary>
    public static SvgIcon Folder => f_Folder ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "folder", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder?f=classic&amp;s=regular">Folder</a>
    /// </summary>
    public static SvgIcon FolderBlank => global::Someplace.FaRegular.Folder;
    private static SvgIcon? f_FolderClosed;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder-closed?f=classic&amp;s=regular">Folder Closed</a>
    /// </summary>
    public static SvgIcon FolderClosed => f_FolderClosed ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "folder-closed", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_FolderOpen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder-open?f=classic&amp;s=regular">Folder Open</a>
    /// </summary>
    public static SvgIcon FolderOpen => f_FolderOpen ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "folder-open", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_FontAwesome;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/font-awesome?f=classic&amp;s=regular">Font Awesome</a>
    /// </summary>
    public static SvgIcon FontAwesome => f_FontAwesome ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "font-awesome", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/font-awesome?f=classic&amp;s=regular">Font Awesome</a>
    /// </summary>
    public static SvgIcon FontAwesomeFlag => global::Someplace.FaRegular.FontAwesome;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/font-awesome?f=classic&amp;s=regular">Font Awesome</a>
    /// </summary>
    public static SvgIcon FontAwesomeLogoFull => global::Someplace.FaRegular.FontAwesome;
    private static SvgIcon? f_Futbol;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/futbol?f=classic&amp;s=regular">Futbol</a>
    /// </summary>
    public static SvgIcon Futbol => f_Futbol ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "futbol", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/futbol?f=classic&amp;s=regular">Futbol</a>
    /// </summary>
    public static SvgIcon FutbolBall => global::Someplace.FaRegular.Futbol;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/futbol?f=classic&amp;s=regular">Futbol</a>
    /// </summary>
    public static SvgIcon SoccerBall => global::Someplace.FaRegular.Futbol;
    private static SvgIcon? f_Gem;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/gem?f=classic&amp;s=regular">Gem</a>
    /// </summary>
    public static SvgIcon Gem => f_Gem ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "gem", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_Hand;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand?f=classic&amp;s=regular">Hand</a>
    /// </summary>
    public static SvgIcon Hand => f_Hand ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand?f=classic&amp;s=regular">Hand</a>
    /// </summary>
    public static SvgIcon HandPaper => global::Someplace.FaRegular.Hand;
    private static SvgIcon? f_HandBackFist;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-back-fist?f=classic&amp;s=regular">Hand Back Fist</a>
    /// </summary>
    public static SvgIcon HandBackFist => f_HandBackFist ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-back-fist", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-back-fist?f=classic&amp;s=regular">Hand Back Fist</a>
    /// </summary>
    public static SvgIcon HandRock => global::Someplace.FaRegular.HandBackFist;
    private static SvgIcon? f_HandLizard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-lizard?f=classic&amp;s=regular">Hand Lizard</a>
    /// </summary>
    public static SvgIcon HandLizard => f_HandLizard ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-lizard", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_HandPeace;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-peace?f=classic&amp;s=regular">Hand Peace</a>
    /// </summary>
    public static SvgIcon HandPeace => f_HandPeace ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-peace", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_HandPointDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-down?f=classic&amp;s=regular">Hand Point Down</a>
    /// </summary>
    public static SvgIcon HandPointDown => f_HandPointDown ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-point-down", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_HandPointLeft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-left?f=classic&amp;s=regular">Hand Point Left</a>
    /// </summary>
    public static SvgIcon HandPointLeft => f_HandPointLeft ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-point-left", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_HandPointRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-right?f=classic&amp;s=regular">Hand Point Right</a>
    /// </summary>
    public static SvgIcon HandPointRight => f_HandPointRight ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-point-right", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_HandPointUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-up?f=classic&amp;s=regular">Hand Point Up</a>
    /// </summary>
    public static SvgIcon HandPointUp => f_HandPointUp ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-point-up", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_HandPointer;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-pointer?f=classic&amp;s=regular">Hand Pointer</a>
    /// </summary>
    public static SvgIcon HandPointer => f_HandPointer ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-pointer", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_HandScissors;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-scissors?f=classic&amp;s=regular">Hand Scissors</a>
    /// </summary>
    public static SvgIcon HandScissors => f_HandScissors ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-scissors", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_HandSpock;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-spock?f=classic&amp;s=regular">Hand Spock</a>
    /// </summary>
    public static SvgIcon HandSpock => f_HandSpock ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hand-spock", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_Handshake;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/handshake?f=classic&amp;s=regular">Handshake</a>
    /// </summary>
    public static SvgIcon Handshake => f_Handshake ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "handshake", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_HardDrive;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hard-drive?f=classic&amp;s=regular">Hard Drive</a>
    /// </summary>
    public static SvgIcon HardDrive => f_HardDrive ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hard-drive", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hard-drive?f=classic&amp;s=regular">Hard Drive</a>
    /// </summary>
    public static SvgIcon Hdd => global::Someplace.FaRegular.HardDrive;
    private static SvgIcon? f_Heart;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/heart?f=classic&amp;s=regular">Heart</a>
    /// </summary>
    public static SvgIcon Heart => f_Heart ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "heart", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_Hospital;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hospital?f=classic&amp;s=regular">Hospital</a>
    /// </summary>
    public static SvgIcon Hospital => f_Hospital ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hospital", "[unicode]", 640, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hospital?f=classic&amp;s=regular">Hospital</a>
    /// </summary>
    public static SvgIcon HospitalAlt => global::Someplace.FaRegular.Hospital;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hospital?f=classic&amp;s=regular">Hospital</a>
    /// </summary>
    public static SvgIcon HospitalWide => global::Someplace.FaRegular.Hospital;
    private static SvgIcon? f_Hourglass;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass?f=classic&amp;s=regular">Hourglass</a>
    /// </summary>
    public static SvgIcon Hourglass => f_Hourglass ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hourglass", "[unicode]", 384, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass?f=classic&amp;s=regular">Hourglass</a>
    /// </summary>
    public static SvgIcon HourglassEmpty => global::Someplace.FaRegular.Hourglass;
    private static SvgIcon? f_HourglassHalf;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass-half?f=classic&amp;s=regular">Hourglass Half</a>
    /// </summary>
    public static SvgIcon HourglassHalf => f_HourglassHalf ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "hourglass-half", "[unicode]", 384, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass-half?f=classic&amp;s=regular">Hourglass Half</a>
    /// </summary>
    public static SvgIcon Hourglass2 => global::Someplace.FaRegular.HourglassHalf;
    private static SvgIcon? f_IdBadge;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/id-badge?f=classic&amp;s=regular">Id Badge</a>
    /// </summary>
    public static SvgIcon IdBadge => f_IdBadge ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "id-badge", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_IdCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/id-card?f=classic&amp;s=regular">Id Card</a>
    /// </summary>
    public static SvgIcon IdCard => f_IdCard ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "id-card", "[unicode]", 576, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/id-card?f=classic&amp;s=regular">Id Card</a>
    /// </summary>
    public static SvgIcon DriversLicense => global::Someplace.FaRegular.IdCard;
    private static SvgIcon? f_Image;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/image?f=classic&amp;s=regular">Image</a>
    /// </summary>
    public static SvgIcon Image => f_Image ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "image", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_Images;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/images?f=classic&amp;s=regular">Images</a>
    /// </summary>
    public static SvgIcon Images => f_Images ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "images", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_Keyboard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/keyboard?f=classic&amp;s=regular">Keyboard</a>
    /// </summary>
    public static SvgIcon Keyboard => f_Keyboard ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "keyboard", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_Lemon;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/lemon?f=classic&amp;s=regular">Lemon</a>
    /// </summary>
    public static SvgIcon Lemon => f_Lemon ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "lemon", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_LifeRing;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/life-ring?f=classic&amp;s=regular">Life Ring</a>
    /// </summary>
    public static SvgIcon LifeRing => f_LifeRing ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "life-ring", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_Lightbulb;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/lightbulb?f=classic&amp;s=regular">Lightbulb</a>
    /// </summary>
    public static SvgIcon Lightbulb => f_Lightbulb ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "lightbulb", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_Map;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/map?f=classic&amp;s=regular">Map</a>
    /// </summary>
    public static SvgIcon Map => f_Map ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "map", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_Message;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/message?f=classic&amp;s=regular">Message</a>
    /// </summary>
    public static SvgIcon Message => f_Message ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "message", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/message?f=classic&amp;s=regular">Message</a>
    /// </summary>
    public static SvgIcon CommentAlt => global::Someplace.FaRegular.Message;
    private static SvgIcon? f_MoneyBill1;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/money-bill-1?f=classic&amp;s=regular">Money Bill 1</a>
    /// </summary>
    public static SvgIcon MoneyBill1 => f_MoneyBill1 ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "money-bill-1", "[unicode]", 576, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/money-bill-1?f=classic&amp;s=regular">Money Bill 1</a>
    /// </summary>
    public static SvgIcon MoneyBillAlt => global::Someplace.FaRegular.MoneyBill1;
    private static SvgIcon? f_Moon;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/moon?f=classic&amp;s=regular">Moon</a>
    /// </summary>
    public static SvgIcon Moon => f_Moon ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "moon", "[unicode]", 384, 512, "[path]");
    private static SvgIcon? f_Newspaper;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/newspaper?f=classic&amp;s=regular">Newspaper</a>
    /// </summary>
    public static SvgIcon Newspaper => f_Newspaper ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "newspaper", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_NoteSticky;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/note-sticky?f=classic&amp;s=regular">Note Sticky</a>
    /// </summary>
    public static SvgIcon NoteSticky => f_NoteSticky ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "note-sticky", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/note-sticky?f=classic&amp;s=regular">Note Sticky</a>
    /// </summary>
    public static SvgIcon StickyNote => global::Someplace.FaRegular.NoteSticky;
    private static SvgIcon? f_ObjectGroup;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/object-group?f=classic&amp;s=regular">Object Group</a>
    /// </summary>
    public static SvgIcon ObjectGroup => f_ObjectGroup ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "object-group", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_ObjectUngroup;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/object-ungroup?f=classic&amp;s=regular">Object Ungroup</a>
    /// </summary>
    public static SvgIcon ObjectUngroup => f_ObjectUngroup ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "object-ungroup", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_PaperPlane;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/paper-plane?f=classic&amp;s=regular">Paper Plane</a>
    /// </summary>
    public static SvgIcon PaperPlane => f_PaperPlane ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "paper-plane", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_Paste;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/paste?f=classic&amp;s=regular">Paste</a>
    /// </summary>
    public static SvgIcon Paste => f_Paste ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "paste", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/paste?f=classic&amp;s=regular">Paste</a>
    /// </summary>
    public static SvgIcon FileClipboard => global::Someplace.FaRegular.Paste;
    private static SvgIcon? f_PenToSquare;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/pen-to-square?f=classic&amp;s=regular">Pen To Square</a>
    /// </summary>
    public static SvgIcon PenToSquare => f_PenToSquare ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "pen-to-square", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/pen-to-square?f=classic&amp;s=regular">Pen To Square</a>
    /// </summary>
    public static SvgIcon Edit => global::Someplace.FaRegular.PenToSquare;
    private static SvgIcon? f_RectangleList;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-list?f=classic&amp;s=regular">Rectangle List</a>
    /// </summary>
    public static SvgIcon RectangleList => f_RectangleList ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "rectangle-list", "[unicode]", 576, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-list?f=classic&amp;s=regular">Rectangle List</a>
    /// </summary>
    public static SvgIcon ListAlt => global::Someplace.FaRegular.RectangleList;
    private static SvgIcon? f_RectangleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static SvgIcon RectangleXmark => f_RectangleXmark ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "rectangle-xmark", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static SvgIcon RectangleTimes => global::Someplace.FaRegular.RectangleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static SvgIcon TimesRectangle => global::Someplace.FaRegular.RectangleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static SvgIcon WindowClose => global::Someplace.FaRegular.RectangleXmark;
    private static SvgIcon? f_Registered;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/registered?f=classic&amp;s=regular">Registered</a>
    /// </summary>
    public static SvgIcon Registered => f_Registered ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "registered", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_ShareFromSquare;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/share-from-square?f=classic&amp;s=regular">Share From Square</a>
    /// </summary>
    public static SvgIcon ShareFromSquare => f_ShareFromSquare ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "share-from-square", "[unicode]", 576, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/share-from-square?f=classic&amp;s=regular">Share From Square</a>
    /// </summary>
    public static SvgIcon ShareSquare => global::Someplace.FaRegular.ShareFromSquare;
    private static SvgIcon? f_Snowflake;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/snowflake?f=classic&amp;s=regular">Snowflake</a>
    /// </summary>
    public static SvgIcon Snowflake => f_Snowflake ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "snowflake", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_Square;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square?f=classic&amp;s=regular">Square</a>
    /// </summary>
    public static SvgIcon Square => f_Square ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_SquareCaretDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-down?f=classic&amp;s=regular">Square Caret Down</a>
    /// </summary>
    public static SvgIcon SquareCaretDown => f_SquareCaretDown ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-caret-down", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-down?f=classic&amp;s=regular">Square Caret Down</a>
    /// </summary>
    public static SvgIcon CaretSquareDown => global::Someplace.FaRegular.SquareCaretDown;
    private static SvgIcon? f_SquareCaretLeft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-left?f=classic&amp;s=regular">Square Caret Left</a>
    /// </summary>
    public static SvgIcon SquareCaretLeft => f_SquareCaretLeft ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-caret-left", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-left?f=classic&amp;s=regular">Square Caret Left</a>
    /// </summary>
    public static SvgIcon CaretSquareLeft => global::Someplace.FaRegular.SquareCaretLeft;
    private static SvgIcon? f_SquareCaretRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-right?f=classic&amp;s=regular">Square Caret Right</a>
    /// </summary>
    public static SvgIcon SquareCaretRight => f_SquareCaretRight ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-caret-right", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-right?f=classic&amp;s=regular">Square Caret Right</a>
    /// </summary>
    public static SvgIcon CaretSquareRight => global::Someplace.FaRegular.SquareCaretRight;
    private static SvgIcon? f_SquareCaretUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-up?f=classic&amp;s=regular">Square Caret Up</a>
    /// </summary>
    public static SvgIcon SquareCaretUp => f_SquareCaretUp ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-caret-up", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-up?f=classic&amp;s=regular">Square Caret Up</a>
    /// </summary>
    public static SvgIcon CaretSquareUp => global::Someplace.FaRegular.SquareCaretUp;
    private static SvgIcon? f_SquareCheck;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-check?f=classic&amp;s=regular">Square Check</a>
    /// </summary>
    public static SvgIcon SquareCheck => f_SquareCheck ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-check", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-check?f=classic&amp;s=regular">Square Check</a>
    /// </summary>
    public static SvgIcon CheckSquare => global::Someplace.FaRegular.SquareCheck;
    private static SvgIcon? f_SquareFull;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-full?f=classic&amp;s=regular">Square Full</a>
    /// </summary>
    public static SvgIcon SquareFull => f_SquareFull ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-full", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_SquareMinus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-minus?f=classic&amp;s=regular">Square Minus</a>
    /// </summary>
    public static SvgIcon SquareMinus => f_SquareMinus ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-minus", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-minus?f=classic&amp;s=regular">Square Minus</a>
    /// </summary>
    public static SvgIcon MinusSquare => global::Someplace.FaRegular.SquareMinus;
    private static SvgIcon? f_SquarePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-plus?f=classic&amp;s=regular">Square Plus</a>
    /// </summary>
    public static SvgIcon SquarePlus => f_SquarePlus ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "square-plus", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-plus?f=classic&amp;s=regular">Square Plus</a>
    /// </summary>
    public static SvgIcon PlusSquare => global::Someplace.FaRegular.SquarePlus;
    private static SvgIcon? f_Star;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star?f=classic&amp;s=regular">Star</a>
    /// </summary>
    public static SvgIcon Star => f_Star ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "star", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_StarHalf;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star-half?f=classic&amp;s=regular">Star Half</a>
    /// </summary>
    public static SvgIcon StarHalf => f_StarHalf ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "star-half", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_StarHalfStroke;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star-half-stroke?f=classic&amp;s=regular">Star Half Stroke</a>
    /// </summary>
    public static SvgIcon StarHalfStroke => f_StarHalfStroke ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "star-half-stroke", "[unicode]", 576, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star-half-stroke?f=classic&amp;s=regular">Star Half Stroke</a>
    /// </summary>
    public static SvgIcon StarHalfAlt => global::Someplace.FaRegular.StarHalfStroke;
    private static SvgIcon? f_Sun;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/sun?f=classic&amp;s=regular">Sun</a>
    /// </summary>
    public static SvgIcon Sun => f_Sun ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "sun", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_ThumbsDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/thumbs-down?f=classic&amp;s=regular">Thumbs Down</a>
    /// </summary>
    public static SvgIcon ThumbsDown => f_ThumbsDown ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "thumbs-down", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_ThumbsUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/thumbs-up?f=classic&amp;s=regular">Thumbs Up</a>
    /// </summary>
    public static SvgIcon ThumbsUp => f_ThumbsUp ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "thumbs-up", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_TrashCan;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/trash-can?f=classic&amp;s=regular">Trash Can</a>
    /// </summary>
    public static SvgIcon TrashCan => f_TrashCan ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "trash-can", "[unicode]", 448, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/trash-can?f=classic&amp;s=regular">Trash Can</a>
    /// </summary>
    public static SvgIcon TrashAlt => global::Someplace.FaRegular.TrashCan;
    private static SvgIcon? f_User;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&amp;s=regular">User</a>
    /// </summary>
    public static SvgIcon User => f_User ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "user", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_WindowMaximize;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/window-maximize?f=classic&amp;s=regular">Window Maximize</a>
    /// </summary>
    public static SvgIcon WindowMaximize => f_WindowMaximize ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "window-maximize", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_WindowMinimize;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/window-minimize?f=classic&amp;s=regular">Window Minimize</a>
    /// </summary>
    public static SvgIcon WindowMinimize => f_WindowMinimize ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "window-minimize", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_WindowRestore;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/window-restore?f=classic&amp;s=regular">Window Restore</a>
    /// </summary>
    public static SvgIcon WindowRestore => f_WindowRestore ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "window-restore", "[unicode]", 512, 512, "[path]");
}