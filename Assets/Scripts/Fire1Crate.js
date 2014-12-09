#pragma strict

var innerCore : ParticleEmitter;
var outerCore : ParticleEmitter;
var smoke : ParticleEmitter;
function Start () {

}

function Update () {

}
function Extinguish() {

	innerCore.emit = false;
	outerCore.emit = false;
	smoke.emit = false;
}