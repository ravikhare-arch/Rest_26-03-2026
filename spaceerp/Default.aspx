<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" EnableEventValidation="false" Inherits="_Default" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<!-- Mirrored from seantheme.com/color-admin-v4.0/admin/html/login_v3.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 14 Mar 2018 08:42:33 GMT -->
<head>
    <meta charset="utf-8" />
    <title>Hotel Premier Inn  Login Page</title>
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <!-- ================== BEGIN BASE CSS STYLE ================== -->
    <link href="./css/loginstyle.css" rel="stylesheet" type="text/css" media="all">

    <!-- ================== END BASE CSS STYLE ================== -->
    <link href="css/keyboard.css" rel="stylesheet" />
   <script src='<%= ResolveUrl("assets/plugins/jquery/jquery-3.2.1.min.js")%>'></script>
</head>
    
<body class="pace-top bg-white">
    <form runat="server">
        <!-- begin #page-loader -->
        <div id="page-loader" class="fade show"><span class="spinner"></span></div>
        <!-- end #page-loader -->
             <asp:Label runat="server" ID="lblmsg"></asp:Label>
        	<h1>Hotel<span>Premier  inn </span>res<span>tau</span>rant</h1> 
        <div class="wthree-form">
		<!--728x90-->
		<h2>Fill out the form below to login</h2>
		<div class="w3l-login form">
		<!--728x90-->
				<div class="form-sub-w3">
                  <asp:TextBox required ID="txtUser" runat="server" class="form-control form-control-lg use-keyboard-input" placeholder="User ID"></asp:TextBox>
				</div>
			    <div class="form-sub-w3">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" class="form-control form-control-lg use-keyboard-input" placeholder="Password"
                                size="30" required></asp:TextBox>

                        </div>
				<label class="anim">
					<input type="checkbox" class="checkbox">
					<span>Remember Me</span> 
				</label>
				<div class="submit-agileits">
                     <asp:Button ID="btn" Text="Sign In" runat="server" CssClass="btn btn-success btn-block btn-lg"
                                OnClick="btn_Click" />

                        				</div>
				<a href="#">Forgot Password ?</a>
		</div>
	</div>      
        <div class="footer-agileits">
		<!--728x90-->
                <p>    &copy; Hotel Premier Inn  All Right Reserved <%= DateTime.Now.Year.ToString() %></p>
		</div>   
                
    <script id="rendered-js">
        const Keyboard = {
            elements: {
                main: null,
                keysContainer: null,
                keys: [] },


            eventHandlers: {
                oninput: null,
                onclose: null },


            properties: {
                value: "",
                capsLock: false },


            init() {
                // Create main elements
                this.elements.main = document.createElement("div");
                this.elements.keysContainer = document.createElement("div");

                // Setup main elements
                this.elements.main.classList.add("keyboard", "keyboard--hidden");
                this.elements.keysContainer.classList.add("keyboard__keys");
                this.elements.keysContainer.appendChild(this._createKeys());

                this.elements.keys = this.elements.keysContainer.querySelectorAll(".keyboard__key");

                // Add to DOM
                this.elements.main.appendChild(this.elements.keysContainer);
                document.body.appendChild(this.elements.main);

                // Automatically use keyboard for elements with .use-keyboard-input
                document.querySelectorAll(".use-keyboard-input").forEach(element => {
                    element.addEventListener("focus", () => {
                        this.open(element.value, currentValue => {
                            element.value = currentValue;
                        });
                    });
                });
            },

            _createKeys() {
                const fragment = document.createDocumentFragment();
                const keyLayout = [
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "backspace",
                "q", "w", "e", "r", "t", "y", "u", "i", "o", "p",
                "caps", "a", "s", "d", "f", "g", "h", "j", "k", "l", "enter",
                "done", "z", "x", "c", "v", "b", "n", "m", ",", ".", "?",
                "space"];


                // Creates HTML for an icon
                const createIconHTML = icon_name => {
                    return `<i class="material-icons">${icon_name}</i>`;
                };

                keyLayout.forEach(key => {
                    const keyElement = document.createElement("button");
                    const insertLineBreak = ["backspace", "p", "enter", "?"].indexOf(key) !== -1;

                    // Add attributes/classes
                    keyElement.setAttribute("type", "button");
                    keyElement.classList.add("keyboard__key");

                    switch (key) {
                        case "backspace":
                            keyElement.classList.add("keyboard__key--wide");
                            keyElement.innerHTML = createIconHTML("backspace");

                            keyElement.addEventListener("click", () => {
                                this.properties.value = this.properties.value.substring(0, this.properties.value.length - 1);
                                this._triggerEvent("oninput");
                            });

                            break;

                        case "caps":
                            keyElement.classList.add("keyboard__key--wide", "keyboard__key--activatable");
                            keyElement.innerHTML = createIconHTML("keyboard_capslock");

                            keyElement.addEventListener("click", () => {
                                this._toggleCapsLock();
                                keyElement.classList.toggle("keyboard__key--active", this.properties.capsLock);
                            });

                            break;

                        case "enter":
                            keyElement.classList.add("keyboard__key--wide");
                            keyElement.innerHTML = createIconHTML("keyboard_return");

                            keyElement.addEventListener("click", () => {
                                this.properties.value += "\n";
                                this._triggerEvent("oninput");
                            });

                            break;

                        case "space":
                            keyElement.classList.add("keyboard__key--extra-wide");
                            keyElement.innerHTML = createIconHTML("space_bar");

                            keyElement.addEventListener("click", () => {
                                this.properties.value += " ";
                                this._triggerEvent("oninput");
                            });

                            break;

                        case "done":
                            keyElement.classList.add("keyboard__key--wide", "keyboard__key--dark");
                            keyElement.innerHTML = createIconHTML("check_circle");

                            keyElement.addEventListener("click", () => {
                                this.close();
                                this._triggerEvent("onclose");
                            });

                            break;

                        default:
                            keyElement.textContent = key.toLowerCase();

                            keyElement.addEventListener("click", () => {
                                this.properties.value += this.properties.capsLock ? key.toUpperCase() : key.toLowerCase();
                                this._triggerEvent("oninput");
                            });

                            break;}


                    fragment.appendChild(keyElement);

                    if (insertLineBreak) {
                        fragment.appendChild(document.createElement("br"));
                    }
                });

                return fragment;
            },

            _triggerEvent(handlerName) {
                if (typeof this.eventHandlers[handlerName] == "function") {
                    this.eventHandlers[handlerName](this.properties.value);
                }
            },

            _toggleCapsLock() {
                this.properties.capsLock = !this.properties.capsLock;

                for (const key of this.elements.keys) {
                    if (key.childElementCount === 0) {
                        key.textContent = this.properties.capsLock ? key.textContent.toUpperCase() : key.textContent.toLowerCase();
                    }
                }
            },

            open(initialValue, oninput, onclose) {
                this.properties.value = initialValue || "";
                this.eventHandlers.oninput = oninput;
                this.eventHandlers.onclose = onclose;
                this.elements.main.classList.remove("keyboard--hidden");
            },

            close() {
                this.properties.value = "";
                this.eventHandlers.oninput = oninput;
                this.eventHandlers.onclose = onclose;
                this.elements.main.classList.add("keyboard--hidden");
            } };


        window.addEventListener("DOMContentLoaded", function () {
            Keyboard.init();
        });
        //# sourceURL=pen.js
    </script>
    <div class="keyboard keyboard--hidden">
        <div class="keyboard__keys">
            <button type="button" class="keyboard__key">`</button>
            <button type="button" class="keyboard__key">1</button>
            <button type="button" class="keyboard__key">2</button>
            <button type="button" class="keyboard__key">3</button>
            <button type="button" class="keyboard__key">4</button>
            <button type="button" class="keyboard__key">5</button>
            <button type="button" class="keyboard__key">6</button>
            <button type="button" class="keyboard__key">7</button>
            <button type="button" class="keyboard__key">8</button>
            <button type="button" class="keyboard__key">9</button>
            <button type="button" class="keyboard__key">0</button>
            <button type="button" class="keyboard__key">=</button>
            <button type="button" class="keyboard__key keyboard__key--wide">
                <i class="material-icons">backspace</i>
            </button><br>
            <button type="button" class="keyboard__key">q</button>
            <button type="button" class="keyboard__key">w</button>
            <button type="button" class="keyboard__key">e</button>
            <button type="button" class="keyboard__key">r</button>
            <button type="button" class="keyboard__key">t</button>
            <button type="button" class="keyboard__key">y</button>
            <button type="button" class="keyboard__key">u</button>
            <button type="button" class="keyboard__key">i</button>
            <button type="button" class="keyboard__key">o</button>
            <button type="button" class="keyboard__key">p</button><br>
            <button type="button" class="keyboard__key keyboard__key--wide keyboard__key--activatable"><i class="material-icons">keyboard_capslock</i></button>
            <button type="button" class="keyboard__key">a</button>
            <button type="button" class="keyboard__key">s</button><button type="button" class="keyboard__key">d</button>
            <button type="button" class="keyboard__key">f</button>
            <button type="button" class="keyboard__key">g</button><button type="button" class="keyboard__key">h</button>
            <button type="button" class="keyboard__key">j</button>
            <button type="button" class="keyboard__key">k</button><button type="button" class="keyboard__key">l</button>
            <button type="button" class="keyboard__key keyboard__key--wide"><i class="material-icons">keyboard_return</i></button><br>
            <button type="button" class="keyboard__key keyboard__key--wide keyboard__key--dark"><i class="material-icons">check_circle</i></button>
            <button type="button" class="keyboard__key">z</button><button type="button" class="keyboard__key">x</button>
            <button type="button" class="keyboard__key">c</button>
            <button type="button" class="keyboard__key">v</button><button type="button" class="keyboard__key">b</button>
            <button type="button" class="keyboard__key">n</button>
            <button type="button" class="keyboard__key">m</button><button type="button" class="keyboard__key">,</button>
            <button type="button" class="keyboard__key">.</button>
            <button type="button" class="keyboard__key">?</button><br>
            <button type="button" class="keyboard__key keyboard__key--extra-wide"><i class="material-icons">space_bar</i></button>
        </div>
    </div>
                   <script>
            $(document).ready(function () {
                //App.init();
                $.ajax({
                    url: "https://mumbai.rstpms.com/Hotel/API/GetOccupiedRooms",
                    type: "GET",
                    contentType: "application/json",
                    dataType: "json",
                    data: {
                        companyid: 1040
                    },
                    success: function (data) {
                        console.log("API se ye data aaya:", data);
                        // Duplicate RoomNo remove karne ke liye
                    }
                });
            });
                   </script>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            // C# Session se values nikal rahe hain
            var loginId = '<%= Session["nLoginId"] %>';
        var sLogin = '<%= Session["sLogin"] %>';
        var fullName = '<%= Session["sUserFullName"] %>';

        // Debugging ke liye console me check karo
        console.log("Checking Session Data:", loginId, fullName);

        if (loginId !== "" && loginId !== "null" && loginId !== undefined) {

            // 1. Pehle LocalStorage mein save karo
            localStorage.setItem("nLoginId", loginId);
            localStorage.setItem("sLogin", sLogin);
            localStorage.setItem("sUserFullName", fullName);

            console.log("Data Saved! redirecting to Dashboard...");

            // 2. Ab JavaScript se redirect karo
            window.location.href = "Dashboard.aspx";
        }
    });
    </script>
</body>
</html>
