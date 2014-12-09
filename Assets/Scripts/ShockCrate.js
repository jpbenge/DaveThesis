#pragma strict

var parts : ParticleEmitter;
function Start () {

}

function Update () {

}
function Scramble() {
	parts = GetComponentInChildren(ParticleEmitter);
	parts.emit = false;
}