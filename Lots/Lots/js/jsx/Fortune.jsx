(function (React, ReactDOM, $, i18n, Identity) {
    var FortuneRequestData = { select_01: 1, textfield: "", R1: 0, DrawLots: new Array() };

    var FortuneResult = React.createClass({
        componentDidMount: function() {
	        $('html, body').animate({ scrollTop: 0 }, 'fast');          
        },
        textfieldChange: function(event) {
            FortuneRequestData.textfield = event.target.value;
            this.forceUpdate();
        },
        select_01Change: function(event){
            FortuneRequestData.select_01 = parseInt(event.target.value);
            this.forceUpdate();
        },
        R1_Change: function(event){
            FortuneRequestData.R1 = parseInt(event.target.value);
            this.forceUpdate();
        },
        render: function() {
            return (
                <div>
                    <h2 className="content-subhead">{i18n.FortuneSub1}</h2>
                    <p>
                        {FortuneRequestData.textfield}
                    </p>
                    <h2 className="content-subhead">{i18n.FortuneSub2}</h2>
                    <p>
                        {this.props.Result1}
                    </p>
                    <h2 className="content-subhead">{i18n.FortuneSub3}</h2>
                    <p>
                        {this.props.Result2}
                    </p>
                    <h2 className="content-subhead">{i18n.FortuneSub4}</h2>
                    <div className="pure-g">
                        <div className="pure-u-1">
                            {i18n.Opportunity}：{this.props.Result3}
            </div>
            <div className="pure-u-1">
                {i18n.Environment}：{this.props.Result4}
            </div>
            <div className="pure-u-1">
                {i18n.Social}：{this.props.Result5}
            </div>
        </div>
        <h2 className="content-subhead">{i18n.FortuneSub5}</h2>
        <table className="pure-table">
            <thead>
                <tr>
                    <th>{i18n.spring}</th>
                    <th>{i18n.summer}</th>
                    <th>{i18n.autumn}</th>
                    <th>{i18n.winter}</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{this.props.Result6}</td>
                    <td>{this.props.Result7}</td>
                    <td>{this.props.Result8}</td>
                    <td>{this.props.Result9}</td>
                </tr>
            </tbody>
        </table>
        <h2 className="content-subhead">{i18n.FortuneSub6}</h2>
        <div className="pure-g">
            <div className="pure-u-1-3">

            </div>
            <div className="pure-u-1-3">
                <dl>
                    <dt>{i18n.north}</dt>
                    <dd>{this.props.Result10}</dd>
                </dl>
            </div>
            <div className="pure-u-1-3">

            </div>
            <div className="pure-u-1-3">
                <dl>
                    <dt>{i18n.west}</dt>
                    <dd>{this.props.Result11}</dd>
                </dl>
            </div>
            <div className="pure-u-1-3">
                <dl>
                    <dt>{i18n.Surroundings}</dt>
                    <dd>{this.props.Result12}</dd>
                </dl>
            </div>
            <div className="pure-u-1-3">
                <dl>
                    <dt>{i18n.east}</dt>
                    <dd>{this.props.Result13}</dd>
                </dl>
            </div>
            <div className="pure-u-1-3">

            </div>
            <div className="pure-u-1-3">
                <dl>
                    <dt>{i18n.south}</dt>
                    <dd>{this.props.Result14}</dd>
                </dl>
            </div>
            <div className="pure-u-1-3">

            </div>
        </div>
        <h2 className="content-subhead">{i18n.FortuneSub7}</h2>
        <p>
            {this.props.Result15}
        </p>
        <h2 className="content-subhead">{i18n.FortuneSub8}</h2>
        <p>
            {this.props.Result16}
        </p>
    </div>
            );
        }
    });            

    var RequestForm = React.createClass({
        componentDidMount: function() {
            //this.getData();
        },
        textfieldChange: function(event) {
            FortuneRequestData.textfield = event.target.value;
            this.forceUpdate();
        },
        select_01Change: function(event){
            FortuneRequestData.select_01 = parseInt(event.target.value);
            this.forceUpdate();
        },
        R1_Change: function(event){
            FortuneRequestData.R1 = parseInt(event.target.value);
            this.forceUpdate();
        },
        render: function() {
            var select_01op = new Array();
            for (var i = 1; i <= 7 ; i++) {
                select_01op.push(<option value={i} key={i}>{i18n["select_01_"+i]}</option>);
        }

    var R1 = new Array();
    for (var i = 1; i <= 8 ; i++) {
        R1.push(<div className="pure-u-1-2" key={i}><label htmlFor={"R1_"+i} className="pure-radio"><input id={"R1_"+i} type="radio" onChange={this.R1_Change} name="R1" value={i} checked={i === FortuneRequestData.R1} required/>{i18n["R1_"+i]}</label></div>);
    }

    var playChess = this.props.playChess;

    return (
            <form className="pure-form pure-form-stacked" onSubmit={playChess}><fieldset>
                            <div className="pure-g">
                                <div className="pure-u-1">
                                    <label htmlFor="select_01">{i18n.SelectCategory}</label>
                                    <select id="select_01" value={FortuneRequestData.select_01} onChange={this.select_01Change}>
                                        {select_01op}
                                    </select>
                                </div>
                                <div className="pure-u-1">
                                    <label htmlFor="textfield">{i18n.Question1} : {i18n.Note1}</label>
                                    <input id="textfield" onChange={this.textfieldChange} type="text" placeholder={i18n.Question1} className="pure-input-1" value={FortuneRequestData.textfield} autoComplete="off" required />
                                </div>
                                <div className="pure-u-1">
                                    <label>{i18n.Specific}</label>
{R1}
</div>
<div className="pure-u-1">
    <label>{i18n.Note2}</label>
    <button type="submit" className="pure-button pure-button-primary">{i18n.Submit1}</button>
</div>
</div>
</fieldset></form>
);
}
});
    /*------------------------*/
    var chessSlots = new Array();

    var ChessLots = React.createClass({
        componentDidMount: function() {
            $('html, body').animate({ scrollTop: 0 }, 'fast');
        },
        textfieldChange: function(event) {
            FortuneRequestData.textfield = event.target.value;
            this.forceUpdate();
        },
        select_01Change: function(event){
            FortuneRequestData.select_01 = parseInt(event.target.value);
            this.forceUpdate();
        },
        R1_Change: function(event){
            FortuneRequestData.R1 = parseInt(event.target.value);
            this.forceUpdate();
        },
        onChessPick: function(Idx) {
            if (FortuneRequestData.DrawLots.length < 6) {
                FortuneRequestData.DrawLots.push(Idx);
                this.forceUpdate();
                if (FortuneRequestData.DrawLots.length == 6) {
                    this.goRandom();
                }
            }
        },
        goRandom: function() {
            for (var i = 0; i < 32 ; i++) {
                if (FortuneRequestData.DrawLots.indexOf(i) == -1) {
                    chessSlots.push(i);
                }
            }

            for (var i = 0; i < chessSlots.length ; i++) {
                var TempChessLot = chessSlots[i];
                var random_num = parseInt(Math.random() * chessSlots.length);
                chessSlots[i] = chessSlots[random_num];
                chessSlots[random_num] = TempChessLot;
            }

            setTimeout(this.randomPick, 100);

        },
        randomPick: function() {
            var chessSlotsIdx = chessSlots[0];
            chessSlots.splice(0, 1);
            FortuneRequestData.DrawLots.push(chessSlotsIdx);
            this.forceUpdate();

            if (chessSlots.length > 0) {
                setTimeout(this.randomPick, 100);
            } else {
                this.props.getData();
                $('html, body').animate({ scrollTop: document.body.scrollHeight }, 'fast');
            }
        },
        render: function() {
            var chessLots = new Array();
            for (var i = 1; i <= 32 ; i++) {
                if (FortuneRequestData.DrawLots.indexOf(i - 1) > -1) {
                    chessLots.push(<div key={i} className="pure-u-1-4 pure-u-md-1-8"><div className="chessSel"></div></div>);
                }else{
                    chessLots.push(<div key={i} className="pure-u-1-4 pure-u-md-1-8"><div className="chessLot" onClick={FortuneRequestData.DrawLots.length < 6 ? this.onChessPick.bind(null, i - 1) : null} style={{ cursor: FortuneRequestData.DrawLots.length < 6 ? "pointer" : null } }></div></div>);
                }
            }

            var chessLotsPanel = <div className="pure-g">{chessLots}</div>;
            var ChessLv = 1;
            var ChessIdx = 1;
            var ChessFinal = new Array();

            while (ChessIdx <= 32) {
                var ChessRow = new Array();
                for (var i = 1; i <= ChessLv ; i++) {
                    if (ChessIdx > 32) break;
                    if (this.props.FortuneResult==null){
                        ChessRow.push(<div key={ChessIdx} style={{ backgroundColor: FortuneRequestData.DrawLots.length >= ChessIdx ? "#006500" : null } }></div>);
                    } else {
                        var sChess = this.props.FortuneResult.chessSlots[ChessIdx - 1].charAt(0);

                        ChessRow.push(<div key={ChessIdx} className={"chessPieces" + (sChess >= "h" ? " black" : " red") }><div><span>{i18n[sChess]}</span></div></div>);
                    }
                    ChessIdx++;
                }
                ChessFinal.push(<div key={ChessLv} className="ccle">{ChessRow}</div>);
                ChessLv++;
            }

            var btnToResult = this.props.FortuneResult == null ? null : <div className="pure-u-1"><button type="button" onClick={this.props.goToResult} className="pure-button pure-button-primary">{i18n.Submit2}</button></div>;

            return (
                    <div>
                        <p>{i18n.Note3}</p>
                        {chessLotsPanel}
                        <hr/>
                        {ChessFinal}
                        {btnToResult}
                    </div>
            );
        }
    });
    /*------------------------*/

var FortunePanel = React.createClass({
    getInitialState: function() {
        return {Step:0};
    },
    componentDidMount: function() {
        //this.getData();
    },
    playChess: function(e){
        e.preventDefault();
        this.setState({Step: 1});
    },
    getData: function() {
        var tmpxhr = this.xhr;
        if (tmpxhr) {
            this.xhr = null;
            tmpxhr.abort();
        }

        this.xhr = $.ajax({
            url: Identity.FortuneResult,
            dataType: "jsonp",
            jsonp: "jsoncallback",
            method: "POST",
            traditional: true,
            data: FortuneRequestData,
            success: function (data) {
                if (this.isMounted()) {
                    this.setState({ FortuneResult: data });
                    //setTimeout(this.goToResult, 1500);
                }
            }.bind(this),
            error: function (jqXHR, textStatus, errorThrown) {
                if (textStatus === "abort" && jqXHR !== this.xhr) return;
                alert(jqXHR.statusText);
            }.bind(this)
        });

    },
    goToResult: function(){
        this.setState({Step: 2});
    },
    render: function() {
        var Form = null;
        if(this.state.Step==0)
        {
            Form = <RequestForm playChess={this.playChess}/>;
        } else if(this.state.Step==1){
            Form = <ChessLots getData={this.getData} goToResult={this.goToResult} FortuneResult={this.state.FortuneResult}/>;
        }else if(this.state.Step==2){
            Form = <FortuneResult {...this.state.FortuneResult}/>;
        }

        return (<div>{Form}</div>);
    }
});

window.RequestFormPanelRef = ReactDOM.render(<FortunePanel />, $(".content").get(0));
})(React, ReactDOM, jQuery, i18n, Identity);